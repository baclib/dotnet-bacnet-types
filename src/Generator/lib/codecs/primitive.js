// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { toPascalCase, toCamelCase } from '../core/text.js';

const unsignedVariants = ['byte', 'ushort', 'uint', 'ulong'].map((type, index) => {
	const size = 8 << index;
	const max = (1n << BigInt(size)) - 1n;
	return { type, size, min: 0n, max };
});

const integerVariants = ['sbyte', 'short', 'int', 'long'].map((type, index) => {
	const size = 8 << index;
	const exponent = BigInt(size - 1);
	const min = -(1n << exponent);
	const max = (1n << exponent) - 1n;
	return { type, size, min, max };
});

export function getUnsignedVariant(minimum, maximum) {
	for (const variant of unsignedVariants) {
		if (minimum >= variant.min && maximum <= variant.max) {
			return variant;
		}
	}
	return null;
}

export function getIntegerVariant(minimum, maximum) {
	for (const variant of integerVariants) {
		if (minimum >= variant.min && maximum <= variant.max) {
			return variant;
		}
	}
	return null;
}

const dateMembers = ['year', 'month', 'day', 'day-of-week'];

const timeMembers = ['hour', 'minute', 'second', 'hundredths'];

const weekNDayMembers = ['month', 'week', 'day-of-week'];

export const maxLength = 2147483647;

export const typesWithMinMax = ['unsigned', 'integer', 'real', 'double', 'enumerated'];

export const stringLikeBaseTypes = new Set(['octet-string', 'character-string', 'bit-string']);

export const predefinedTypeDefinitions = [
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
];

export function enhancePredefinedTypes(sourceTypes = predefinedTypeDefinitions) {
	const enhancedTypes = [];

	function pushType(sourceType) {
		const name = sourceType.name;
		const typeName = toPascalCase(name);
		const className = `${typeName}Codec`;
		const csharpType = sourceType.type ?? typeName;
		const underlyingType = sourceType.base ?? null;
		const isNull = name === 'null';
		const isBoolean = name === 'boolean';
		const isBitString = name.startsWith('bit-string');
        const isEnumerated = name.startsWith('enumerated');
		const hasFixedSize = Object.hasOwn(sourceType, 'size');
		const hasMembers = Array.isArray(sourceType.members);
		const hasRange = Object.hasOwn(sourceType, 'base');
		const hasLength = name.endsWith('-string');
		const baseType = {
			name,
			typeName,
			className,
			csharpType,
			tagName: sourceType.tagName ?? typeName,
			...(underlyingType ? { underlyingType } : {}),
			...(isNull ? { isNull } : {}),
			...(isBoolean ? { isBoolean } : {}),
			...(isBitString ? { isBitString } : {}),
			...(hasFixedSize ? { fixedSize: sourceType.size } : {}),
			...(hasFixedSize ? { lengthConstant: typeName } : {}),
			...(hasMembers ? { members: { private: sourceType.members.map(toCamelCase), public: sourceType.members.map(toPascalCase) } } : {}),
			...(hasRange ? { range: { minimum: `${csharpType}.MinValue`, maximum: `${csharpType}.MaxValue` } } : {}),
			...(hasLength ? { length: { minimum: `${csharpType}.MinLength`, maximum: `${csharpType}.MaxLength` } } : {}),
			...(isEnumerated ? { isEnumerated } : {}),
			...(sourceType.variant ? { variant: sourceType.variant } : {})
		};
		enhancedTypes.push(baseType);
	}

	for (const sourceType of sourceTypes) {
		if (sourceType.variants) {
			const { variants, ...specificSourceType } = sourceType;
			pushType({ ...specificSourceType, levels: [8, 16, 32], variant: variants[2] });
			const levels = [];
			sourceType.variants.forEach((variant) => {
				const variantType = {
					name: `${sourceType.name}-${variant.size}`,
					tagName: toPascalCase(sourceType.name),
					variant,
					...(sourceType.type ? { type: variant.type } : { base: variant.type }),
					...(levels.length ? { levels } : { size: 1 })
				};
				levels.push(variant.size);
				pushType(variantType);
			});
		}
		else {
			pushType(sourceType);
			if (sourceType.name.endsWith('-pattern')) {
				pushType({ ...sourceType, name: sourceType.name.replace('-pattern', ''), tagName: toPascalCase(sourceType.name) });
			}
		}
	}

	return enhancedTypes;
}

export const predefinedCodecs = enhancePredefinedTypes(predefinedTypeDefinitions);
