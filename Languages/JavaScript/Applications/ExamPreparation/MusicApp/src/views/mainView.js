import { html } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

import { navigationTemplate } from './navigationView.js';

export const mainTemplate = (templateResult, ctx) =>
    html`<div id="box">
        <header>${navigationTemplate(ctx.auth.isLogged())}</header>

        <main id="main-content">${templateResult}</main>

        <footer>
            <div>&copy;SoftUni Team 2021. All rights reserved.</div>
        </footer>
    </div>`;
