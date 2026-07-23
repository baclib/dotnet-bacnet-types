// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { EOL } from 'os';

/**
 * Converts a kebab-case BACnet identifier to PascalCase (e.g. "object-identifier" -> "ObjectIdentifier").
 */
export function toPascalCase(kebabCase) {
    return kebabCase
        .split('-')
        .map(part => part.charAt(0).toUpperCase() + part.slice(1))
        .join('');
}

/**
 * Converts an identifier to camelCase using the same segment logic as toPascalCase
 * (e.g. "object-identifier" -> "objectIdentifier", "ObjectIdentifier" -> "objectIdentifier").
 */
export function toCamelCase(value) {
    const pascalCase = toPascalCase(value);
    return pascalCase.charAt(0).toLowerCase() + pascalCase.slice(1);
}

/**
 * Normalizes all line endings in generated content to the current platform's EOL.
 */
export function normalizeLineEndings(content) {
    return content.replace(/\r\n|\n|\r/g, EOL);
}
