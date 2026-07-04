// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//
// Unified entry point for the BACnet C# code generators.
//
// Usage:
//   node generate.js [command]
//
// Commands are defined in lib/registry.js. Run without a command to generate types, or pass
// "all" to run the full type + codec pipeline.
//

import { defaultCommand, findGenerator, generators } from './lib/registry.js';

function printUsage() {
    const commandWidth = Math.max(...generators.map(generator => generator.name.length));
    console.log('Usage: node generate.js [command]\n');
    console.log('Commands:');
    for (const generator of generators) {
        console.log(`  ${generator.name.padEnd(commandWidth)}  ${generator.description}`);
    }
    console.log(`\nDefault command: ${defaultCommand}`);
}

async function main() {
    const requested = process.argv[2];

    if (requested === '--help' || requested === '-h' || requested === 'help') {
        printUsage();
        return;
    }

    const commandName = requested ?? defaultCommand;
    const generator = findGenerator(commandName);

    if (!generator) {
        console.error(`Unknown command: ${commandName}\n`);
        printUsage();
        process.exitCode = 1;
        return;
    }

    await generator.run();
}

await main();
