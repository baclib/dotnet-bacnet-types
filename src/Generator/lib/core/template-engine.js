// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import fs from 'fs/promises';
import Handlebars from 'handlebars';
import { normalizeLineEndings } from './text.js';

/**
 * Shared Handlebars rendering pipeline used by every generator.
 *
 * Provides a per-instance template cache, template loading with configurable HTML escaping,
 * and EOL-normalized rendering. Generators extend this class to inherit the rendering helpers.
 */
export class TemplateEngine {
    /**
     * @param {{ noEscape?: boolean }} [options] Set noEscape to true for generators that emit raw C#.
     */
    constructor(options = {}) {
        this.templateCache = new Map();
        this.noEscape = Boolean(options.noEscape);
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
        return normalizeLineEndings(content);
    }
}
