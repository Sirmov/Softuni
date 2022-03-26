// Dom related

import { html } from './lib.js';

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
export const loading = html`Loading &hellip;`;

// Spinner gif
export const spinner = html`<div
    className="spinner"
    style="display: flex;
    align-items: center;
    justify-content: center;
    height: 70px;
    width: 70px"
>
    <img src="https://upload.wikimedia.org/wikipedia/commons/2/29/Loader.gif" alt="Loading" />
</div>`;
