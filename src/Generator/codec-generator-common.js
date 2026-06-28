// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import Handlebars from 'handlebars';

export const partials = Object.freeze([
    'number', 'unsigned', 'integer', 'real', 'double',
    'octet-string', 'character-string', 'bit-string', 'enumerated',
    'choice', 'sequence', 'sequence-of'
]);

export const codecOverrides = Object.freeze({
    'boolean': 'BooleanCodec',
    'null': 'NullCodec',
    'unsigned': 'UnsignedCodec',
    'object-identifier': 'ObjectIdentifierCodec',
    'property-identifier': 'PropertyIdentifierCodec',
    'enumerated': 'Enumerated32Codec',
    'enumerated-32': 'Enumerated32Codec',
    'date-pattern': 'DatePatternCodec',
    'week-n-day': 'WeekNDayCodec'
});

export const nativeAliases = Object.freeze({
    'boolean': 'bool',
    'unsigned': 'uint',
    'unsigned-8': 'byte',
    'unsigned-16': 'ushort',
    'unsigned-32': 'uint',
    'unsigned-64': 'ulong',
    'integer': 'int',
    'integer-8': 'sbyte',
    'integer-16': 'short',
    'integer-32': 'int',
    'integer-64': 'long',
    'real': 'float',
    'double': 'double',
    'string': 'string'
});

const primitiveBaseTypes = new Set([
    'boolean',
    'null',
    'unsigned',
    'integer',
    'real',
    'double',
    'octet-string',
    'character-string',
    'bit-string',
    'enumerated',
    'object-identifier',
    'week-n-day',
    'date-pattern',
    'time-pattern'
]);

const constructedBaseTypes = new Set(['choice', 'sequence', 'sequence-of']);

export class CodecGeneratorBase {
    constructor(baseDir, options) {
        // Shared override for all codec generators, used by generate-all-codecs.js
        this.directory = process.env.CODEC_OUTPUT_DIR
            ? path.resolve(baseDir, process.env.CODEC_OUTPUT_DIR)
            : path.join(baseDir, '..', '..', 'local-working-files', 'codecs');
        this.templatesDir = path.join(baseDir, 'templates', 'codecs');
        this.templateCache = new Map();
        this.typeRegistry = new Map();
        this.filter = process.env[options.filterEnvName] ?? null;
        this.noEscape = Boolean(options.noEscape);
    }

    registerType(context) {
        const current = this.typeRegistry.get(context.fullname) ?? {};
        const next = { ...current };

        if (context.traits) {
            next.baseType = this.isSeries(context) ? 'sequence-of' : context.traits.base;
        }

        if (typeof context.definition?.type === 'string') {
            next.aliasTo = context.definition.type;
        }

        this.typeRegistry.set(context.fullname, next);
    }

    isSeries(context) {
        return context.traits && Object.hasOwn(context.traits, 'series') && context.traits.series !== false;
    }

    matchesFilter(fullname) {
        if (!this.filter) {
            return true;
        }

        return fullname === this.filter || this.getTypeHierarchy(fullname).join('.') === this.filter;
    }

    resolveKind(fullname, visited = new Set()) {
        if (visited.has(fullname)) {
            return 'primitive';
        }
        visited.add(fullname);

        const metadata = this.typeRegistry.get(fullname);
        const baseType = metadata?.baseType;

        if (baseType) {
            if (constructedBaseTypes.has(baseType)) {
                return 'constructed';
            }
            if (primitiveBaseTypes.has(baseType)) {
                return 'primitive';
            }
        }

        if (metadata?.aliasTo) {
            return this.resolveKind(metadata.aliasTo, visited);
        }

        if (constructedBaseTypes.has(fullname)) {
            return 'constructed';
        }

        return 'primitive';
    }

    getItemValueType(fullname) {
        if (Object.hasOwn(nativeAliases, fullname)) {
            return nativeAliases[fullname];
        }

        return this.getTypeHierarchy(fullname).at(-1);
    }

    getItemTypeReference(fullname) {
        if (Object.hasOwn(nativeAliases, fullname)) {
            return nativeAliases[fullname];
        }

        return this.getTypeReference(fullname);
    }

    getCodecReference(fullname) {
        if (Object.hasOwn(codecOverrides, fullname)) {
            return codecOverrides[fullname];
        }

        return `${this.getTypeHierarchy(fullname).join('')}Codec`;
    }

    getTypeReference(fullname) {
        return `global::Baclib.Bacnet.Types.Application.${this.getTypeHierarchy(fullname).join('.')}`;
    }

    getTypeHierarchy(fullname) {
        const resolvedFullname = this.resolveKnownFullname(fullname);
        return resolvedFullname
            .split('.')
            .map((part, index) => (index ? 'T' : '') + this.toPascalCase(part));
    }

    resolveKnownFullname(fullname) {
        if (!fullname.includes('.') || this.typeRegistry.size === 0) {
            return fullname;
        }

        const parts = fullname.split('.');
        const resolvedParts = [parts[0]];
        let currentPath = parts[0];

        for (let i = 1; i < parts.length; i++) {
            const part = parts[i];
            const hasMoreSegments = i < parts.length - 1;

            if (hasMoreSegments && part.startsWith('list-of-')) {
                const itemVariant = `${part}-item`;
                resolvedParts.push(itemVariant);
                currentPath = `${currentPath}.${itemVariant}`;
                continue;
            }

            const exactPath = `${currentPath}.${part}`;
            if (this.typeRegistry.has(exactPath)) {
                const metadata = this.typeRegistry.get(exactPath);
                const itemVariant = `${part}-item`;
                const itemVariantPath = `${currentPath}.${itemVariant}`;

                if (hasMoreSegments && metadata?.baseType === 'sequence-of' && this.typeRegistry.has(itemVariantPath)) {
                    resolvedParts.push(itemVariant);
                    currentPath = itemVariantPath;
                    continue;
                }

                resolvedParts.push(part);
                currentPath = exactPath;
                continue;
            }

            const itemVariant = `${part}-item`;
            const itemVariantPath = `${currentPath}.${itemVariant}`;
            if (this.typeRegistry.has(itemVariantPath)) {
                resolvedParts.push(itemVariant);
                currentPath = itemVariantPath;
                continue;
            }

            resolvedParts.push(part);
            currentPath = exactPath;
        }

        const deduplicatedParts = [];
        for (const part of resolvedParts) {
            if (deduplicatedParts.at(-1) === part) {
                continue;
            }
            deduplicatedParts.push(part);
        }

        return deduplicatedParts.join('.');
    }

    async loadTemplate(templatePath) {
        if (this.templateCache.has(templatePath)) {
            return this.templateCache.get(templatePath);
        }

        const templateContent = await fs.readFile(templatePath, 'utf-8');
        const compiledTemplate = Handlebars.compile(templateContent, { noEscape: this.noEscape });
        this.templateCache.set(templatePath, compiledTemplate);
        return compiledTemplate;
    }

    async render(templatePath, data) {
        const template = await this.loadTemplate(templatePath);
        return this.normalizeLineEndings(template(data));
    }

    normalizeLineEndings(content) {
        return content.replace(/\r\n|\n|\r/g, EOL);
    }

    toCamelCase(value) {
        return value.charAt(0).toLowerCase() + value.slice(1);
    }

    toPascalCase(kebabCase) {
        return kebabCase
            .split('-')
            .map(part => part.charAt(0).toUpperCase() + part.slice(1))
            .join('');
    }
}
