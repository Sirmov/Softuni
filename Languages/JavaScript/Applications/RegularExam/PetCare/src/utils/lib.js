// Module used for convenience

import { html, render, nothing } from '../../node_modules/lit-html/lit-html.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { until } from '../../node_modules/lit-html/directives/until.js';
import page from '../../node_modules/page/page.mjs';

const lit = { html, render, repeat, until, nothing };

export { page, lit, html, render, repeat, until, nothing };
