// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import path from 'path';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { toPascalCase } from '../core/text.js';
import { codecsOutputDir, generatorRoot } from '../core/paths.js';
import { ignoredCodecTypeNames } from '../core/constants.js';
import { createFixedCodecGenerator } from './fixed.js';
import { createChoiceCodecGenerator } from './choice.js';
import { createSequenceCodecGenerator } from './sequence.js';

// Codec generators run in dependency order: primitives first, then the constructed and
// restriction generators that reference them.
const codecGeneratorFactories = Object.freeze([
    createFixedCodecGenerator,
    createChoiceCodecGenerator,
    createSequenceCodecGenerator
]);

// Environment filters that scope individual codec generators to a single type. They must be
// cleared for a full run so stale values from a previous targeted run cannot leak through.
const codecFilterEnvNames = Object.freeze([
    'CHOICE_CODEC_FILTER',
    'SEQUENCE_CODEC_FILTER',
    'ENUM_CODEC_FILTER',
    'RESTRICTED_CODEC_FILTER',
    'BITSTRING_CODEC_FILTER'
]);

async function cleanOutputDirectory(directory) {
    await fs.mkdir(directory, { recursive: true });
    const files = await fs.readdir(directory);

    await Promise.all(
        files
            .filter(file => file.endsWith('.cs'))
            .map(file => fs.unlink(path.join(directory, file)))
    );
}

async function removeIgnoredCodecs(directory) {
    const ignoredPrefixes = ignoredCodecTypeNames.map(toPascalCase);
    const existingFiles = await fs.readdir(directory);

    const filesToRemove = existingFiles.filter(file => {
        if (!file.endsWith('Codec.cs')) {
            return false;
        }
        // Remove the ignored type's own codec as well as any of its nested subtype codecs
        // (named "<Prefix>T...Codec"). PDU types live outside Baclib.Bacnet.Types.Application
        // and must not produce codecs.
        return ignoredPrefixes.some(prefix =>
            file === `${prefix}Codec.cs` || file.startsWith(`${prefix}T`));
    });

    await Promise.all(
        filesToRemove.map(async file => {
            const targetPath = path.join(directory, file);
            try {
                await fs.unlink(targetPath);
            }
            catch (error) {
                if (error?.code !== 'ENOENT') {
                    throw error;
                }
            }
        })
    );
}

async function writeAnyCodec(directory) {
    const anyCodecPath = path.join(directory, 'AnyCodec.cs');
    const anyCodecContent = `// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Placeholder implementation. Replace with full Any handling.
public sealed class AnyCodec :
    IAsduElementCodec<T.Any>,
    IAsduPrimitiveCodec<T.Any>
{
    public static T.Any Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<AnyCodec, T.Any>(ref reader);

    public static T.Any Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<AnyCodec, T.Any>(ref reader, tagNumber);

    public static T.Any DecodeValue(ReadOnlySpan<byte> source)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static void Encode(ref AsduWriter writer, in T.Any value)
        => AsduPrimitive.Encode<AnyCodec, T.Any>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
        => AsduPrimitive.Encode<AnyCodec, T.Any>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any encoder.");

    public static int GetEncodedValueLength(in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any length calculator.");

    public static int GetEncodedLength(in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static int GetEncodedLength(in T.Any value, byte tagNumber)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.Null;
}
`;

    await fs.writeFile(anyCodecPath, anyCodecContent, 'utf-8');
}

/**
 * Generates every ASDU codec in-process and writes them to the output directory.
 *
 * @param {{ outputDir?: string }} [options] Overrides the default AsduCodecs output directory.
 */
export async function generateCodecs(options = {}) {
    const outputDir = options.outputDir
        ?? (process.env.ALL_CODECS_OUTPUT_DIR
            ? path.resolve(generatorRoot, process.env.ALL_CODECS_OUTPUT_DIR)
            : codecsOutputDir);

    // Each codec generator resolves its output from CODEC_OUTPUT_DIR. Point them all at the
    // shared directory and clear any per-generator filters so a full run is always complete.
    process.env.CODEC_OUTPUT_DIR = outputDir;
    for (const name of codecFilterEnvNames) {
        delete process.env[name];
    }

    await cleanOutputDirectory(outputDir);

    for (const createGenerator of codecGeneratorFactories) {
        await traverseDefinitions(createGenerator());
    }

    await writeAnyCodec(outputDir);
    await removeIgnoredCodecs(outputDir);

    console.log(`All codecs generated in: ${outputDir}`);
}
