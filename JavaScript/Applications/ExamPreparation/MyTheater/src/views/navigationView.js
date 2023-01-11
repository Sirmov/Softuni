import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (isLogged, onLogout) =>
    html`<nav>
        <a href="/">Theater</a>
        <ul>
            ${isLogged
                ? html`<!--Only users-->
                      <li><a href="/profile">Profile</a></li>
                      <li><a href="/create">Create Event</a></li>
                      <li><a href="javascript:void(0)" @click=${onLogout}>Logout</a></li>`
                : html`<!--Only guest-->
                      <li><a href="/login">Login</a></li>
                      <li><a href="/register">Register</a></li>`}
        </ul>
    </nav>`;
