import { lit } from '../lib.js';
import { loading } from '../utils.js';
import { navigationTemplate } from './navigationView.js';

export const mainTemplate = (templateResult, ctx) =>
    lit.html`<div id="container">
        <header>
            ${navigationTemplate(ctx.auth.isLoggedIn(), ctx.auth.getUserUsername())}
        </header>
        <main id="site-content">
            ${templateResult}
        </main>
        <footer>
            <p>&copy; All rights reserved</p>
        </footer>
    </div>`;
