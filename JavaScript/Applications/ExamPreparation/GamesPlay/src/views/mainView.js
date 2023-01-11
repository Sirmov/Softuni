import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';
import { navigationTemplate } from './navigationView.js';
import { isLogged } from '../utils/auth.js';

export const mainTemplate = (templateResult) =>
    html`<div id="box">
        <header>${navigationTemplate(isLogged())}</header>

        <!-- Main Content -->
        <main id="main-content">${templateResult}</main>
    </div>`;
