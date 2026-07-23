// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//
// Shared vocabulary for the BACnet code generators. Centralizing these tables keeps the type
// generator, codec generators, and orchestrator in agreement about base types, aliases, and the
// set of PDU types that must never produce application types or codecs.
//

/** Base type names that have a dedicated Handlebars partial in the type generator. */
export const partials = Object.freeze([
    'number', 'unsigned', 'integer', 'real', 'double',
    'octet-string', 'character-string', 'bit-string', 'enumerated',
    'choice', 'sequence', 'sequence-of'
]);

/** Concrete PDU type names. These live outside the application namespace. */
export const pduTypes = Object.freeze([
    'confirmed-request-pdu',
    'unconfirmed-request-pdu',
    'simple-ack-pdu',
    'complex-ack-pdu',
    'segment-ack-pdu',
    'error-pdu',
    'reject-pdu',
    'abort-pdu'
]);

/** PDU type names (including the abstract `pdu`) whose codecs must be removed after generation. */
export const ignoredCodecTypeNames = Object.freeze(['pdu', ...pduTypes]);

/** Predefined / refined types rendered from the dedicated `predefined.hbs` template. */
export const refinedTypes = Object.freeze([
    'any', 'choice', 'sequence', 'sequence-of',
    'null',
    'octet-string', 'character-string', 'bit-string', 'bit-string-8', 'bit-string-16', 'bit-string-32', 'bit-string-64',
    'date-pattern', 'time-pattern',
    'object-identifier',
    'week-n-day'
]);

/** Type-generator aliases: BACnet type fullname -> C# alias target. */
export const fixedAliases = Object.freeze({
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
    'string': 'string',
    'enumerated': 'uint',
    'enumerated-8': 'byte',
    'enumerated-16': 'ushort',
    'enumerated-32': 'uint',
    'enumerated-64': 'ulong',
    'enumeration': 'uint'
});

/** Codec-generator aliases: BACnet type name -> native C# member type. */
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

/** Codec class name overrides keyed by BACnet base type name. */
export const codecOverrides = Object.freeze({
    'boolean': 'BooleanCodec',
    'null': 'NullCodec',
    'unsigned': 'UnsignedCodec',
    'object-identifier': 'ObjectIdentifierCodec',
    'property-identifier': 'PropertyIdentifierCodec',
    'enumerated': 'EnumeratedCodec',
    'enumerated-32': 'Enumerated32Codec',
    'date-pattern': 'DatePatternCodec',
    'week-n-day': 'WeekNDayCodec'
});

// Type reference overrides keyed by BACnet base type name. Used when the C# member type
// for a BACnet type differs from the name derived from the type hierarchy.
export const typeReferenceOverrides = Object.freeze({});

/** Base types whose codecs are primitive (single tagged value). */
export const primitiveBaseTypes = Object.freeze(new Set([
    'null',
    'boolean',
    'unsigned',
    'integer',
    'real',
    'double',
    'octet-string',
    'character-string',
    'bit-string',
    'enumerated',
    'date-pattern',
    'time-pattern',
    'object-identifier',
    'week-n-day'
]));

/** Base types whose codecs are constructed (tagged sequences/choices). */
export const constructedBaseTypes = Object.freeze(new Set(['choice', 'sequence', 'sequence-of']));
