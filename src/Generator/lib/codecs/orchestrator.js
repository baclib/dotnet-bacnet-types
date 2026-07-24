// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import path from 'path';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { toPascalCase } from '../core/text.js';
import { codecsOutputDir, generatorRoot, workingDir } from '../core/paths.js';
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

// Hand-written codecs that live in the generated output directory but are maintained by hand
// and must never be deleted or regenerated. Any file ending in `.manual.cs` is preserved too.
const preservedCodecFiles = Object.freeze([
    'AnyCodec.cs'
]);

function isPreservedCodecFile(file) {
    return preservedCodecFiles.includes(file) || file.endsWith('.manual.cs');
}

async function cleanOutputDirectory(directory) {
    await fs.mkdir(directory, { recursive: true });
    const files = await fs.readdir(directory);

    await Promise.all(
        files
            .filter(file => file.endsWith('.cs') && !isPreservedCodecFile(file))
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

/**
 * Generates every ASDU codec in-process and writes them to the output directory.
 *
 * @param {{ outputDir?: string }} [options] Overrides the default AsduCodecs output directory.
 * @returns {Promise<string[]>} Generated codec file names as a JavaScript array.
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

    let codecTypes = [];
    for (const createGenerator of codecGeneratorFactories) {
        const generator = createGenerator();
        await traverseDefinitions(generator);
        codecTypes = [...codecTypes, ...generator.codecTypes];
    }

    // AnyCodec.cs is hand-written (full Any handling) and preserved by cleanOutputDirectory,
    // so it is intentionally not (re)generated here.
    await removeIgnoredCodecs(outputDir);

    const generatedCodecs = (await fs.readdir(outputDir))
        .filter(file => file.endsWith('Codec.cs') && !isPreservedCodecFile(file))
        .sort((left, right) => left.localeCompare(right));

    const generatedCodecNames = new Set(generatedCodecs.map(file => file.slice(0, -3)));
    codecTypes = codecTypes
        .filter(codec => generatedCodecNames.has(codec.codec))
        .sort((a, b) => a.codec.localeCompare(b.codec));

    console.log(`[codecs] Generated ${codecTypes.length} codec files in: ${outputDir}`);
    await fs.writeFile(path.join(workingDir, 'x-all-codecs.json'), JSON.stringify(codecTypes, null, 4) + '\n', 'utf-8');

    //console.log(`Generated codecs JSON: ${JSON.stringify(generatedCodecs, null, 2)}`);
    //console.log(`[codecs] Generated ${generatedCodecs.length} codec files in: ${outputDir}`);

    return generatedCodecs;
}
