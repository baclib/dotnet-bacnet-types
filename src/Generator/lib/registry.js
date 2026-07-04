// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { generateTypes } from './type-generator.js';
import { generateCodecs } from './codecs/orchestrator.js';
import { generateBitStringTypes } from './bit-string-types.js';
import { generateBitStringReport } from './bit-string-report.js';

/**
 * Registry of generator plugins exposed by the CLI.
 *
 * Each plugin declares a command name, a short description, and a `run` function. The CLI
 * resolves commands against this list, so adding a generator only requires registering it here.
 */
export const generators = Object.freeze([
    {
        name: 'types',
        description: 'Generate BACnet application types (records, enums, bit-string structs).',
        run: () => generateTypes()
    },
    {
        name: 'codecs',
        description: 'Generate all ASDU codecs into the Native serialization project.',
        run: () => generateCodecs()
    },
    {
        name: 'bit-string-types',
        description: 'Generate stand-alone bit-string structs into the working folder.',
        run: () => generateBitStringTypes()
    },
    {
        name: 'bit-string-report',
        description: 'Generate the bit-string definitions HTML report.',
        run: () => generateBitStringReport()
    },
    {
        name: 'all',
        description: 'Run the full pipeline: types followed by codecs.',
        run: async () => {
            await generateTypes();
            await generateCodecs();
        }
    }
]);

/** Default command used when the CLI is invoked without arguments. */
export const defaultCommand = 'types';

/** Looks up a generator plugin by command name. */
export function findGenerator(name) {
    return generators.find(generator => generator.name === name) ?? null;
}
