// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import path from 'path';
import { fileURLToPath } from 'url';
import { spawn } from 'child_process';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const outputDir = process.env.ALL_CODECS_OUTPUT_DIR
    ? path.resolve(__dirname, process.env.ALL_CODECS_OUTPUT_DIR)
    //: path.resolve(__dirname, '..', '..', 'local-working-files', 'all-codecs');
    : path.resolve(__dirname, '..', 'Baclib.Bacnet.Serialization.Native', 'AsduCodecs');

const generators = [
    'generate-fixed-codecs.js',
    'generate-enum-codecs.js',
    'generate-choice-codecs.js',
    'generate-sequence-codecs.js',
    'generate-bit-string-codecs.js'
];

const ignoredCodecTypeNames = [
    'pdu',
    'confirmed-request-pdu',
    'unconfirmed-request-pdu',
    'simple-ack-pdu',
    'complex-ack-pdu',
    'segment-ack-pdu',
    'error-pdu',
    'reject-pdu',
    'abort-pdu'
];

async function cleanOutputDirectory(directory) {
    await fs.mkdir(directory, { recursive: true });
    const files = await fs.readdir(directory);

    await Promise.all(
        files
            .filter(file => file.endsWith('.cs'))
            .map(file => fs.unlink(path.join(directory, file)))
    );
}

async function runNodeScript(scriptName, env) {
    return new Promise((resolve, reject) => {
        const child = spawn(process.execPath, [scriptName], {
            cwd: __dirname,
            stdio: 'inherit',
            env
        });

        child.on('error', reject);
        child.on('exit', code => {
            if (code === 0) {
                resolve();
                return;
            }
            reject(new Error(`Generator ${scriptName} failed with exit code ${code}.`));
        });
    });
}

function toPascalCase(kebabCase) {
    return kebabCase
        .split('-')
        .map(part => part.charAt(0).toUpperCase() + part.slice(1))
        .join('');
}

function toCodecFileName(fullname) {
    const hierarchy = fullname
        .split('.')
        .map((part, index) => (index ? 'T' : '') + toPascalCase(part));

    return `${hierarchy.join('')}Codec.cs`;
}

async function removeIgnoredCodecs(directory) {
    const ignoredFiles = ignoredCodecTypeNames.map(toCodecFileName);

    await Promise.all(
        ignoredFiles.map(async file => {
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
    public static T.Any Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<AnyCodec, T.Any>(ref reader);

    public static T.Any Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<AnyCodec, T.Any>(ref reader, tagNumber);

    public static T.Any DecodeValue(ReadOnlySpan<byte> source)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static void Encode(ref NativeWriter writer, in T.Any value)
        => Asdu.EncodePrimitive<AnyCodec, T.Any>(ref writer, value);

    public static void Encode(ref NativeWriter writer, byte tagNumber, in T.Any value)
        => Asdu.EncodePrimitive<AnyCodec, T.Any>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any encoder.");

    public static int GetEncodedValueLength(in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any length calculator.");

    public static int GetLength(in T.Any value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetLength(in T.Any value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref NativeReader reader)
        => reader.PeekPrimitiveTag(TagNumber);

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekPrimitiveTag(tagNumber);

    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.Null;
}
`;

    await fs.writeFile(anyCodecPath, anyCodecContent, 'utf-8');
}

async function main() {
    await cleanOutputDirectory(outputDir);

    const env = {
        ...process.env,
        CODEC_OUTPUT_DIR: outputDir
    };

    // Ensure one-shot run always generates all codecs, independent of previous filter env values.
    delete env.CHOICE_CODEC_FILTER;
    delete env.SEQUENCE_CODEC_FILTER;
    delete env.ENUM_CODEC_FILTER;
    delete env.BITSTRING_CODEC_FILTER;

    for (const scriptName of generators) {
        await runNodeScript(scriptName, env);
    }

    await writeAnyCodec(outputDir);

    await removeIgnoredCodecs(outputDir);

    console.log(`All codecs generated in: ${outputDir}`);
}

await main();
