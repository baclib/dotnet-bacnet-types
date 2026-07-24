// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

/**
 * Generates the AnyCodec.Dispatch.cs partial class file, which contains the auto-generated
 * nested `Codecs` class with static dispatch for all known primitive Any value types.
 *
 * @module lib/codecs/any-dispatch
 * @see docs/codec-generation.md
 */

import fs from 'fs/promises';
import path from 'path';
import { TemplateEngine } from '../core/template-engine.js';
import { codecTemplatesDir } from '../core/paths.js';

/** Output file name for the generated partial class. */
const OUTPUT_FILE = 'AnyCodec.Dispatch.cs';

/** Template path for the AnyCodec dispatch nested class. */
const TEMPLATE_PATH = path.join(codecTemplatesDir, 'any-codec-dispatch.hbs');

/**
 * All dispatch entries in the order they appear in the generated switch/if-chain.
 *
 * Mirrors the type coverage of the former hand-written AnyStaticDispatch:
 *   - T.AnyPrimitive first (special wrapper type)
 *   - C# primitive types for each BACnet primitive family
 *   - BACnet application struct types
 *
 * Entries where csharpType is a C# keyword need `@` prefix when used as identifiers
 * (handled via the `atVarName` field, used in switch pattern-match arms).
 */
const dispatchEntries = Object.freeze([
    { csharpType: 'T.AnyPrimitive',     varName: 'anyPrimitive',       atVarName: 'anyPrimitive',       codecClass: 'AnyPrimitiveCodec' },
    { csharpType: 'bool',               varName: 'bool',               atVarName: '@bool',              codecClass: 'BooleanCodec' },
    { csharpType: 'byte',               varName: 'byte',               atVarName: '@byte',              codecClass: 'Unsigned8Codec' },
    { csharpType: 'ushort',             varName: 'ushort',             atVarName: '@ushort',            codecClass: 'Unsigned16Codec' },
    { csharpType: 'uint',               varName: 'uint',               atVarName: '@uint',              codecClass: 'UnsignedCodec' },
    { csharpType: 'ulong',              varName: 'ulong',              atVarName: '@ulong',             codecClass: 'Unsigned64Codec' },
    { csharpType: 'sbyte',              varName: 'sbyte',              atVarName: '@sbyte',             codecClass: 'Integer8Codec' },
    { csharpType: 'short',              varName: 'short',              atVarName: '@short',             codecClass: 'Integer16Codec' },
    { csharpType: 'int',                varName: 'int',                atVarName: '@int',               codecClass: 'IntegerCodec' },
    { csharpType: 'long',               varName: 'long',               atVarName: '@long',              codecClass: 'Integer64Codec' },
    { csharpType: 'float',              varName: 'float',              atVarName: '@float',             codecClass: 'RealCodec' },
    { csharpType: 'double',             varName: 'double',             atVarName: '@double',            codecClass: 'DoubleCodec' },
    { csharpType: 'BitString',          varName: 'bitString',          atVarName: 'bitString',          codecClass: 'BitStringCodec' },
    { csharpType: 'CharacterString',    varName: 'characterString',    atVarName: 'characterString',    codecClass: 'CharacterStringCodec' },
    { csharpType: 'DatePattern',        varName: 'datePattern',        atVarName: 'datePattern',        codecClass: 'DatePatternCodec' },
    { csharpType: 'Enumerated',         varName: 'enumerated',         atVarName: 'enumerated',         codecClass: 'EnumeratedCodec' },
    { csharpType: 'ObjectIdentifier',   varName: 'objectIdentifier',   atVarName: 'objectIdentifier',   codecClass: 'ObjectIdentifierCodec' },
    { csharpType: 'OctetString',        varName: 'octetString',        atVarName: 'octetString',        codecClass: 'OctetStringCodec' },
    { csharpType: 'TimePattern',        varName: 'timePattern',        atVarName: 'timePattern',        codecClass: 'TimePatternCodec' },
]);

/**
 * Generates `AnyCodec.Dispatch.cs` in the given output directory.
 *
 * @param {string} outputDir Absolute path to the AsduCodecs output directory.
 */
export async function generateAnyDispatch(outputDir) {
    const engine = new TemplateEngine({ noEscape: true });
    const content = await engine.render(TEMPLATE_PATH, { entries: dispatchEntries });
    const outputPath = path.join(outputDir, OUTPUT_FILE);
    await fs.writeFile(outputPath, content, 'utf-8');
    console.log(`  Generated: ${OUTPUT_FILE}`);
}
