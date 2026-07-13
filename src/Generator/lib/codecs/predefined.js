// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

/**
 * Primitive source type definitions and type-variant lookups for BACnet ASN.1 encoding.
 * Exports both indexed (array) and name-indexed (object) collections for flexible access patterns.
 * 
 * @module lib/codecs/predefined
 * @see docs/codec-generation.md
 */

import { toPascalCase, toCamelCase } from '../core/text.js';

const unsignedVariants = Object.freeze(['byte', 'ushort', 'uint', 'ulong'].map((type, index) => {
    const size = 8 << index;
    const max = (1n << BigInt(size)) - 1n;
    return Object.freeze({ type, size, min: 0n, max });
}));

/**
 * Find the smallest type variant that fits the given minimum and maximum values.
 * Uses binary search properties: variants are pre-sorted by size.
 * 
 * @param {Array<Object>} variants - Array of type variants with size/min/max bounds
 * @param {bigint} minimum - Minimum value to accommodate
 * @param {bigint} maximum - Maximum value to accommodate
 * @returns {Object|null} Matching variant with smallest size, or null if none fits
 */
function getTypedVariant(variants, minimum, maximum) {
    return variants.find(v => minimum >= v.min && maximum <= v.max) ?? null;
}

export function getUnsignedVariant(minimum, maximum) {
    return getTypedVariant(unsignedVariants, minimum, maximum);
}

const integerVariants = Object.freeze(['sbyte', 'short', 'int', 'long'].map((type, index) => {
    const size = 8 << index;
    const exponent = BigInt(size - 1);
    const min = -(1n << exponent);
    const max = (1n << exponent) - 1n;
    return Object.freeze({ type, size, min, max });
}));

export function getIntegerVariant(minimum, maximum) {
    return getTypedVariant(integerVariants, minimum, maximum);
}

const dateMembers = Object.freeze(['year', 'month', 'day', 'day-of-week']);

const timeMembers = Object.freeze(['hour', 'minute', 'second', 'hundredths']);

const weekNDayMembers = Object.freeze(['month', 'week', 'day-of-week']);

const sourceTypeDefinitions = Object.freeze([
    { name: 'null', size: 0 },
    { name: 'boolean', size: 1, type: 'bool' },
    { name: 'unsigned', type: 'uint', variants: unsignedVariants },
    { name: 'integer', type: 'int', variants: integerVariants },
    { name: 'real', type: 'float', size: 4 },
    { name: 'double', type: 'double', size: 8 },
    { name: 'octet-string' },
    { name: 'character-string' },
    { name: 'bit-string', base: 'uint', variants: unsignedVariants },
    { name: 'enumerated', base: 'uint', variants: unsignedVariants },
    { name: 'date-pattern', size: 4, members: dateMembers },
    { name: 'time-pattern', size: 4, members: timeMembers },
    { name: 'object-identifier', size: 4 },
    { name: 'week-n-day', size: 3, members: weekNDayMembers, tagName: 'OctetString' }
]);

/**
 * Build an enhanced type object with normalized properties for code generation.
 * Combines source type metadata with source naming conventions and C# type mappings.
 * 
 * @param {Object} sourceType - Source type definition from sourceTypeDefinitions
 * @param {string|null} tagName - ASDU tag name (null for base types)
 * @param {string} typeName - PascalCase type name for C# code generation
 * @returns {Object} Enhanced source type with all properties needed by templates
 */
function buildEnhancedType(sourceType, tagName, typeName) {
    const name = sourceType.name;
    const csharpType = sourceType.type ?? typeName;
    const underlyingType = !name.endsWith('-string') ? sourceType.base ?? null : null;

    const baseType = {
        name,
        typeName,
        [`is${typeName}`]: true,
        isDerived: !!tagName,
        ...(tagName ? { [`is${tagName}`]: true } : {}),
        tagName: tagName ?? typeName,
        className: `${typeName}Codec`,
        csharpType,
    };

    if (underlyingType) baseType.underlyingType = underlyingType;
    if (Object.hasOwn(sourceType, 'size')) baseType.lengthConstant = typeName;
    if (Array.isArray(sourceType.members)) {
        baseType.members = {
            private: sourceType.members.map(toCamelCase),
            public: sourceType.members.map(toPascalCase)
        };
    }
    if (sourceType.variant) baseType.variant = sourceType.variant;

    return baseType;
}

function buildSourceType(sourceTypes = sourceTypeDefinitions) {
    const enhancedTypes = [];

    function pushType(sourceType) {
        const typeName = toPascalCase(sourceType.name);
        const tagName = sourceType.tagName ?? null;
        const enhancedType = buildEnhancedType(sourceType, tagName, typeName);
        enhancedTypes.push(enhancedType);
    }

    for (const sourceType of sourceTypes) {
        pushType(sourceType);
        (sourceType.variants || []).forEach((variant) => {
            const variantType = {
                name: `${sourceType.name}-${variant.size}`,
                tagName: toPascalCase(sourceType.name),
                variant: { size: variant.size, type: variant.type },
                ...(sourceType.type ? { type: variant.type } : { base: variant.type })
            };
            pushType(variantType);
        });
        if (sourceType.name.endsWith('-pattern')) {
            pushType({ ...sourceType, name: sourceType.name.replace('-pattern', ''), tagName: toPascalCase(sourceType.name) });
        }
    }

    return enhancedTypes;
}

/**
 * Array of all primitive and derived source types in order of definition.
 * Use for sequential iteration or when insertion order matters.
 * 
 * @type {Array<Object>} Immutable array of enhanced source type objects
 * @see sourceTypesByName For O(1) name-based lookup
 */
export const sourceTypesByIndex = buildSourceType(sourceTypeDefinitions);

/**
 * Lookup table mapping type names to their source type definitions.
 * Supports O(1) access by name (e.g., sourceTypesByName.boolean, sourceTypesByName['octet-string']).
 * 
 * @type {Object<string, Object>} Frozen object; keys are source type names, values are enhanced source type objects
 * @see sourceTypesByIndex For array-based iteration
 * @example
 * const boolCodec = sourceTypesByName.boolean;
 * const octetCodec = sourceTypesByName['octet-string'];
 * for (const [name, codec] of Object.entries(sourceTypesByName)) { }
 */
export const sourceTypesByName = Object.freeze(
    Object.fromEntries(sourceTypesByIndex.map(codec => [codec.name, codec]))
);
