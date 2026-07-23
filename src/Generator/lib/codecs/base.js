// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import path from 'path';
import { TemplateEngine } from '../core/template-engine.js';
import { toPascalCase, toCamelCase } from '../core/text.js';
import { codecTemplatesDir, generatorRoot, workingDir } from '../core/paths.js';
import {
    codecOverrides,
    constructedBaseTypes,
    nativeAliases,
    primitiveBaseTypes,
    typeReferenceOverrides
} from '../core/constants.js';

/**
 * Shared base class for every codec generator.
 *
 * Builds a registry of type metadata during traversal and exposes the naming, codec-reference,
 * and kind-resolution helpers that the concrete codec generators (choice, sequence, restricted,
 * bit-string, ...) rely on.
 */
export class CodecGeneratorBase extends TemplateEngine {
    constructor(options = {}) {
        super({ noEscape: options.noEscape });

        // Shared override for all codec generators, used by the codec orchestrator.
        this.directory = process.env.CODEC_OUTPUT_DIR
            ? path.resolve(generatorRoot, process.env.CODEC_OUTPUT_DIR)
            : path.join(workingDir, 'codecs');
        this.templatesDir = codecTemplatesDir;
        this.typeRegistry = new Map();
        this.filter = options.filterEnvName ? (process.env[options.filterEnvName] ?? null) : null;
    }

    registerType(context) {
        const current = this.typeRegistry.get(context.fullname) ?? {};
        const next = { ...current };

        if (context.traits) {
            const series = this.isSeries(context);
            next.baseType = series ? 'sequence-of' : context.traits.base;

            // For a SEQUENCE OF, also register the element variant ("<fullname>-item") with the
            // underlying element base type so consumers can resolve the element's codec kind
            // (e.g. a SEQUENCE OF CHOICE element is constructed, not primitive).
            if (series && typeof context.traits.base === 'string') {
                const itemFullname = `${context.fullname}-item`;
                const itemMeta = this.typeRegistry.get(itemFullname) ?? {};
                this.typeRegistry.set(itemFullname, { ...itemMeta, baseType: context.traits.base });
            }
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

    getApplicationTagName(fullname) {
        const metadata = this.typeRegistry.get(fullname);
        const baseType = metadata?.baseType ?? fullname;
        return this.toPascalCase({'integer': 'Signed', 'date': 'DatePattern', 'time': 'TimePattern'}[baseType] ?? baseType);
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

        if (Object.hasOwn(typeReferenceOverrides, fullname)) {
            return typeReferenceOverrides[fullname];
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
        if (Object.hasOwn(typeReferenceOverrides, fullname)) {
			//return `${typeReferenceOverrides[fullname]}`;
            return `global::Baclib.Bacnet.Types.Application.${typeReferenceOverrides[fullname]}`;
        }

		//return `${this.getTypeHierarchy(fullname).join('.')}`;
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

    toCamelCase(value) {
        return toCamelCase(value);
    }

    toPascalCase(kebabCase) {
        return toPascalCase(kebabCase);
    }
}

// Re-exported for backwards compatibility with generators importing vocabulary from the base module.
export { partials } from '../core/constants.js';
