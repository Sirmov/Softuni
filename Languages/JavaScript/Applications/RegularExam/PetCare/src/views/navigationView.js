import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (isLogged, onLogout) =>
    html`<nav>
        <section class="logo">
            <img src="./images/logo.png" alt="logo" />
        </section>
        <ul>
            <!--Users and Guest-->
            <li><a href="/">Home</a></li>
            <li><a href="/dashboard">Dashboard</a></li>
            ${isLogged
                ? html`<!--Only Users-->
                      <li><a href="/create">Create Postcard</a></li>
                      <li><a href="javascript:void(0)" @click=${onLogout}>Logout</a></li>`
                : html`<!--Only Guest-->
                      <li><a href="/login">Login</a></li>
                      <li><a href="/register">Register</a></li>`}
        </ul>
    </nav>`;
