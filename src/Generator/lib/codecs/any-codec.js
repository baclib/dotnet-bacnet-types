// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import path from 'path';
import { TemplateEngine } from '../core/template-engine.js';
import { codecTemplatesDir } from '../core/paths.js';

/** Output file name for the generated Any codec. */
const OUTPUT_FILE = 'AnyCodec.cs';

/** Template path for AnyCodec. */
const TEMPLATE_PATH = path.join(codecTemplatesDir, 'any-codec.hbs');

/**
 * Generates `AnyCodec.cs` in the given output directory.
 *
 * `codecTypes` is passed through so template-based dispatch generation can be
 * introduced incrementally without changing orchestrator plumbing again.
 *
 * @param {string} outputDir Absolute path to the AsduCodecs output directory.
 * @param {{codec:string, type:string}[]} codecTypes Generated codec/type map.
 */
export async function generateAnyCodec(outputDir, codecTypes) {
    const engine = new TemplateEngine({ noEscape: true });
    const content = await engine.render(TEMPLATE_PATH, { codecTypes });
    const outputPath = path.join(outputDir, OUTPUT_FILE);
    await fs.writeFile(outputPath, content, 'utf-8');
    console.log(`  Generated: ${OUTPUT_FILE}`);
}