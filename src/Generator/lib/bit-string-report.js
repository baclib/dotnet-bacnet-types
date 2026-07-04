// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { workingDir } from './core/paths.js';

class BitStringDefinitionReportTransformer {
    constructor() {
        this.outputDirectory = workingDir;
        this.outputFilePath = path.join(this.outputDirectory, 'bit-string-definitions.html');
        this.definitions = [];
    }

    async start() {
        await fs.mkdir(this.outputDirectory, { recursive: true });
    }

    startDefinition(context) {}

    endDefinition(context) {}

    startTraits(context) {
        context.userContext = [];
    }

    endTraits(context) {
        if (context.traits?.base !== 'bit-string') {
            return;
        }

        const bits = Array.isArray(context.userContext)
            ? [...context.userContext].sort((left, right) => this.compareNullableNumber(left.position, right.position))
            : [];

        const lengthInfo = this.getLengthInfo(context.traits, bits);

        this.definitions.push({
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            isSeries: this.isSeries(context),
            lengthInfo,
            bitCount: bits.length,
            bits
        });
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        if (parent?.traits?.base !== 'bit-string') {
            return;
        }

        const item = context.item ?? {};
        parent.userContext.push({
            name: this.toPascalCase(item.name ?? ''),
            bacnetName: item.name ?? '',
            position: this.toInteger(item.position),
            description: item.description ?? ''
        });
    }

    async afterProcessing() {
        this.definitions.sort((left, right) => left.fullname.localeCompare(right.fullname));
        const html = this.renderHtml();
        writeFileSync(this.outputFilePath, html, 'utf-8');
        console.log(`Generated ${this.outputFilePath} with ${this.definitions.length} bit-string definitions.`);
    }

    isSeries(context) {
        return context.traits && Object.hasOwn(context.traits, 'series') && context.traits.series !== false;
    }

    toInteger(value) {
        if (typeof value === 'number' && Number.isInteger(value)) {
            return value;
        }

        if (typeof value === 'string' && /^-?\d+$/.test(value.trim())) {
            return Number.parseInt(value.trim(), 10);
        }

        return null;
    }

    compareNullableNumber(left, right) {
        if (left === null && right === null) {
            return 0;
        }

        if (left === null) {
            return 1;
        }

        if (right === null) {
            return -1;
        }

        return left - right;
    }

    getLengthInfo(traits, bits) {
        const traitLength = traits.length;

        if (Number.isInteger(traitLength)) {
            return {
                kind: 'fixed',
                minimum: traitLength,
                maximum: traitLength,
                text: `${traitLength} bits (fixed)`
            };
        }

        if (traitLength && typeof traitLength === 'object') {
            const minimum = this.toInteger(traitLength.minimum);
            const maximum = this.toInteger(traitLength.maximum);
            return {
                kind: 'range',
                minimum,
                maximum,
                text: `${minimum ?? '?'}..${maximum ?? '?'} bits`
            };
        }

        const definedBitPositions = bits
            .map(bit => bit.position)
            .filter(position => Number.isInteger(position));

        if (definedBitPositions.length > 0) {
            const inferredLength = Math.max(...definedBitPositions) + 1;
            return {
                kind: 'inferred',
                minimum: inferredLength,
                maximum: inferredLength,
                text: `${inferredLength} bits (inferred from bit positions)`
            };
        }

        return {
            kind: 'unspecified',
            minimum: null,
            maximum: null,
            text: 'not specified'
        };
    }

    escapeHtml(value) {
        return String(value)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    renderBitsTable(definition) {
        if (!definition.bits.length) {
            return '<p class="empty-state">No named bits are declared for this definition.</p>';
        }

        const rows = definition.bits.map(bit => {
            const position = bit.position === null ? '<span class="muted">n/a</span>' : this.escapeHtml(bit.position);
            const description = bit.description
                ? this.escapeHtml(bit.description)
                : '<span class="muted">No description</span>';

            return `
                <tr>
                    <td class="mono">${position}</td>
                    <td>
                        <div>${this.escapeHtml(bit.name)}</div>
                        <div class="subtle mono">${this.escapeHtml(bit.bacnetName)}</div>
                    </td>
                    <td>${description}</td>
                </tr>`;
        }).join('');

        return `
            <div class="table-wrap">
                <table>
                    <thead>
                        <tr>
                            <th>Position</th>
                            <th>Bit Name</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>${rows}
                    </tbody>
                </table>
            </div>`;
    }

    renderDefinition(definition) {
        return `
            <section class="card">
                <div class="card-header">
                    <h2>${this.escapeHtml(definition.fullname)}</h2>
                    <span class="chip">${definition.bitCount} bit${definition.bitCount === 1 ? '' : 's'}</span>
                </div>
                <dl class="meta-grid">
                    <div>
                        <dt>BACnet Name</dt>
                        <dd class="mono">${this.escapeHtml(definition.bacnetName)}</dd>
                    </div>
                    <div>
                        <dt>Length</dt>
                        <dd>${this.escapeHtml(definition.lengthInfo.text)}</dd>
                    </div>
                    <div>
                        <dt>Series Type</dt>
                        <dd>${definition.isSeries ? 'yes' : 'no'}</dd>
                    </div>
                </dl>
                ${this.renderBitsTable(definition)}
            </section>`;
    }

    renderHtml() {
        const now = new Date();
        const generatedAt = `${now.toISOString()} (${now.toLocaleString()})`;
        const items = this.definitions.map(definition => this.renderDefinition(definition)).join('\n');

        return `<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>BACnet Bit-String Definitions</title>
    <style>
        :root {
            --bg: #f4f1ea;
            --surface: #fffdfa;
            --ink: #1f2430;
            --ink-soft: #4e5565;
            --muted: #7a8192;
            --stroke: #d5ccb9;
            --accent: #0b6e70;
            --accent-soft: #d9f0f0;
            --chip: #e6eefb;
            --chip-ink: #25408f;
            --shadow: 0 10px 30px rgba(28, 37, 56, 0.08);
        }

        * { box-sizing: border-box; }

        body {
            margin: 0;
            font-family: 'Segoe UI', 'Trebuchet MS', Tahoma, sans-serif;
            color: var(--ink);
            background:
                radial-gradient(1200px 600px at 10% -10%, #f7e7cb 0%, transparent 60%),
                radial-gradient(900px 600px at 90% 0%, #dbedf6 0%, transparent 60%),
                var(--bg);
        }

        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 28px 18px 60px;
        }

        header {
            display: flex;
            flex-wrap: wrap;
            gap: 18px;
            justify-content: space-between;
            align-items: end;
            margin-bottom: 24px;
        }

        h1 {
            margin: 0;
            font-size: clamp(1.6rem, 1.4rem + 1.2vw, 2.3rem);
            letter-spacing: 0.01em;
        }

        .subtitle {
            margin: 6px 0 0;
            color: var(--ink-soft);
            font-size: 0.98rem;
        }

        .counter {
            background: var(--accent-soft);
            color: var(--accent);
            border: 1px solid #b5dbdc;
            border-radius: 999px;
            padding: 8px 14px;
            font-weight: 600;
            white-space: nowrap;
        }

        .cards {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(320px, 1fr));
            gap: 16px;
        }

        .card {
            background: linear-gradient(180deg, #fffefa, var(--surface));
            border: 1px solid var(--stroke);
            border-radius: 14px;
            box-shadow: var(--shadow);
            padding: 16px;
            overflow: hidden;
            animation: rise 450ms ease both;
        }

        .card-header {
            display: flex;
            gap: 10px;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
        }

        h2 {
            margin: 0;
            font-size: 1rem;
            line-height: 1.3;
            word-break: break-word;
        }

        .chip {
            background: var(--chip);
            color: var(--chip-ink);
            border-radius: 999px;
            font-size: 0.82rem;
            padding: 4px 10px;
            font-weight: 700;
        }

        .meta-grid {
            margin: 0 0 12px;
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
            gap: 8px;
        }

        dt {
            font-size: 0.74rem;
            text-transform: uppercase;
            letter-spacing: 0.08em;
            color: var(--muted);
            margin-bottom: 2px;
        }

        dd {
            margin: 0;
            font-size: 0.92rem;
            overflow-wrap: anywhere;
        }

        .mono {
            font-family: Consolas, 'Courier New', monospace;
            font-size: 0.88rem;
        }

        .subtle {
            color: var(--muted);
            margin-top: 1px;
        }

        .muted {
            color: var(--muted);
            font-style: italic;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            font-size: 0.88rem;
            table-layout: fixed;
            min-width: 580px;
        }

        .table-wrap {
            overflow-x: auto;
            border-radius: 10px;
            border: 1px solid #e7decf;
            background: #fffefc;
        }

        th, td {
            text-align: left;
            vertical-align: top;
            padding: 7px 8px;
            border-top: 1px solid #ebe4d8;
            overflow-wrap: anywhere;
        }

        th {
            font-size: 0.74rem;
            text-transform: uppercase;
            letter-spacing: 0.08em;
            color: var(--muted);
            border-top: 1px solid #dcd2c2;
        }

        .empty-state {
            margin: 8px 0 0;
            color: var(--muted);
            font-style: italic;
        }

        @keyframes rise {
            from { transform: translateY(8px); opacity: 0; }
            to { transform: translateY(0); opacity: 1; }
        }

        @media (max-width: 620px) {
            .container {
                padding: 18px 12px 42px;
            }

            .card {
                padding: 12px;
            }

            table {
                min-width: 0;
            }
        }

        @media (prefers-reduced-motion: reduce) {
            .card {
                animation: none;
            }
        }
    </style>
</head>
<body>
    <main class="container">
        <header>
            <div>
                <h1>BACnet Bit-String Definitions</h1>
                <p class="subtitle">Generated on ${this.escapeHtml(generatedAt)}</p>
            </div>
            <div class="counter">${this.definitions.length} definitions</div>
        </header>
        <section class="cards">
${items}
        </section>
    </main>
</body>
</html>`;
    }

    toPascalCase(kebabCase) {
        return kebabCase
            .split('-')
            .filter(Boolean)
            .map(part => part.charAt(0).toUpperCase() + part.slice(1))
            .join('');
    }
}

/** Generates the bit-string definitions HTML report. */
export async function generateBitStringReport() {
    const transformer = new BitStringDefinitionReportTransformer();
    await traverseDefinitions(transformer);
}
