// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//
// Shared classifier for BACnet bit-string definitions.
//
// The type generator, codec generator, and report generator all need to answer the same
// questions about a bit-string definition: how long is it, is the length fixed or variable,
// which C# storage type backs it, and does it need a runtime length field. Centralizing that
// logic here keeps every generator in agreement and makes the taxonomy explicit.
//
// A bit-string falls into exactly one of four categories:
//
//   | category         | length            | storage                        | length field |
//   | ---------------- | ----------------- | ------------------------------ | ------------ |
//   | variable-array   | arbitrary         | byte[]                         | yes (count)  |
//   | bounded-scalar   | variable, max<=64 | byte / ushort / uint / ulong   | yes (count)  |
//   | fixed-scalar     | fixed, len<=64    | byte / ushort / uint / ulong   | no (const)   |
//   | fixed-array      | fixed, len>64     | byte[]                         | no (const)   |
//

/**
 * Named bit-string primitives that carry an implicit maximum length but remain variable-length.
 * These map to `BitString8/16/32/64` in the domain model.
 */
export const specialVariableLengths = new Map([
    ['bit-string-8', 8],
    ['bit-string-16', 16],
    ['bit-string-32', 32],
    ['bit-string-64', 64]
]);

/** The four bit-string categories. */
export const BitStringCategory = Object.freeze({
    VariableArray: 'variable-array',
    BoundedScalar: 'bounded-scalar',
    FixedScalar: 'fixed-scalar',
    FixedArray: 'fixed-array'
});

/** Coerces a value to an integer, returning `null` when it cannot be represented as one. */
export function toInteger(value) {
    if (typeof value === 'number' && Number.isInteger(value)) {
        return value;
    }

    if (typeof value === 'bigint') {
        const asNumber = Number(value);
        return Number.isInteger(asNumber) ? asNumber : null;
    }

    if (typeof value === 'string' && /^-?\d+$/.test(value.trim())) {
        return Number.parseInt(value.trim(), 10);
    }

    return null;
}

/**
 * Determines whether a traversal context represents the abstract `bit-string` primitive
 * (as opposed to a refined bit-string type carrying `traits`).
 */
export function isPrimitiveBitString(context) {
    if (context.traits !== undefined) {
        return false;
    }

    return context.definition?.primitive === 8 || context.fullname === 'bit-string';
}

/** Determines whether a traversal context represents a `SEQUENCE OF` (series) definition. */
export function isBitStringSeries(context) {
    return context.traits
        && Object.hasOwn(context.traits, 'series')
        && context.traits.series !== false;
}

/**
 * Resolves the length envelope for a bit-string definition.
 *
 * @param {number|object|undefined} lengthTrait The declared `length` trait (integer, `{minimum, maximum}`, or absent).
 * @param {number|null} inferredFixedLength Length inferred from the highest declared bit position, when present.
 * @param {string} fullname The definition's full name (used to detect the special variable primitives).
 * @returns {{minimum: number, maximum: number|null, isVariable: boolean}}
 */
export function resolveLengthInfo(lengthTrait, inferredFixedLength, fullname) {
    if (specialVariableLengths.has(fullname)) {
        return { minimum: 0, maximum: specialVariableLengths.get(fullname), isVariable: true };
    }

    if (Number.isInteger(lengthTrait)) {
        return { minimum: lengthTrait, maximum: lengthTrait, isVariable: false };
    }

    if (lengthTrait && typeof lengthTrait === 'object') {
        const minimum = toInteger(lengthTrait.minimum) ?? 0;
        const maximum = toInteger(lengthTrait.maximum);
        if (minimum === maximum && maximum !== null) {
            return { minimum, maximum, isVariable: false };
        }
        return { minimum, maximum, isVariable: true };
    }

    if (Number.isInteger(inferredFixedLength)) {
        return { minimum: inferredFixedLength, maximum: inferredFixedLength, isVariable: false };
    }

    return { minimum: 0, maximum: null, isVariable: true };
}

/** Selects the smallest C# storage type able to hold the given maximum bit length. */
export function resolveStorageType(maxLength) {
    if (!Number.isInteger(maxLength)) {
        return 'byte[]';
    }

    if (maxLength <= 8) {
        return 'byte';
    }
    if (maxLength <= 16) {
        return 'ushort';
    }
    if (maxLength <= 32) {
        return 'uint';
    }
    if (maxLength <= 64) {
        return 'ulong';
    }

    return 'byte[]';
}

/** Selects the C# type used for a runtime bit-count field. */
export function getCountType(maximum) {
    if (!Number.isInteger(maximum)) {
        return 'ushort';
    }

    return maximum > 255 ? 'ushort' : 'byte';
}

/** Returns the fixed byte width of a scalar storage type, or `null` for `byte[]` storage. */
export function getStorageBytes(storageType) {
    switch (storageType) {
        case 'byte':
            return 1;
        case 'ushort':
            return 2;
        case 'uint':
            return 4;
        case 'ulong':
            return 8;
        default:
            return null;
    }
}

/** Classifies a bit-string into one of the four {@link BitStringCategory} values. */
export function classifyCategory(length, storageType) {
    const isArrayStorage = storageType === 'byte[]';

    if (length.isVariable) {
        return isArrayStorage ? BitStringCategory.VariableArray : BitStringCategory.BoundedScalar;
    }

    return isArrayStorage ? BitStringCategory.FixedArray : BitStringCategory.FixedScalar;
}

/**
 * Produces the canonical storage descriptor shared by every bit-string generator.
 *
 * @param {object} options
 * @param {number|object|undefined} options.lengthTrait The declared `length` trait.
 * @param {number|null} [options.inferredFixedLength] Length inferred from bit positions.
 * @param {string} options.fullname The definition's full name.
 * @returns {{
 *   length: {minimum: number, maximum: number|null, isVariable: boolean},
 *   storageType: string,
 *   countType: string,
 *   storageBytes: number|null,
 *   category: string,
 *   isArrayStorage: boolean
 * }}
 */
export function describeBitString({ lengthTrait, inferredFixedLength = null, fullname }) {
    const length = resolveLengthInfo(lengthTrait, inferredFixedLength, fullname);
    // An unbounded bit-string (maximum === null) has no scalar upper bound, so it must use
    // byte[] storage. Passing the null maximum straight through yields that; never fall back
    // to the minimum, which would misclassify an unbounded string as a small scalar.
    const storageType = resolveStorageType(length.maximum);
    const countType = getCountType(length.maximum);
    const storageBytes = getStorageBytes(storageType);
    const category = classifyCategory(length, storageType);

    return {
        length,
        storageType,
        countType,
        storageBytes,
        category,
        isArrayStorage: storageType === 'byte[]'
    };
}
