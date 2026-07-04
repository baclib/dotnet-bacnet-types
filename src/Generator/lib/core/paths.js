// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import path from 'path';
import { fileURLToPath } from 'url';

const __dirname = path.dirname(fileURLToPath(import.meta.url));

/** Absolute path to the Generator project root (the folder containing generate.js). */
export const generatorRoot = path.resolve(__dirname, '..', '..');

/** Absolute path to the repository root. */
export const repoRoot = path.resolve(generatorRoot, '..', '..');

/** Root folder for all Handlebars templates. */
export const templatesDir = path.join(generatorRoot, 'templates');

/** Folder holding codec-specific templates. */
export const codecTemplatesDir = path.join(templatesDir, 'codecs');

/** Default output folder for generated BACnet application types. */
export const typesOutputDir = path.join(generatorRoot, '..', 'Baclib.Bacnet.Types.Application');

/** Default output folder for generated ASDU codecs. */
export const codecsOutputDir = path.join(generatorRoot, '..', 'Baclib.Bacnet.Serialization.Native', 'AsduCodecs');

/** Scratch folder used by report/exploratory generators. */
export const workingDir = path.join(repoRoot, 'local-working-files');
