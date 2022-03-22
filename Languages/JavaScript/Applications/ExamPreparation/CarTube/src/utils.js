// Utility functions

import { lit } from './lib.js';

// Create dom element
export function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach((e) => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

// Loading element
export const loading = lit.html`Loading &hellip;`;

// Spinner gif
export const spinner = lit.html`<img src="https://upload.wikimedia.org/wikipedia/commons/2/29/Loader.gif" style="text-align: center;" alt="Loading">`;
