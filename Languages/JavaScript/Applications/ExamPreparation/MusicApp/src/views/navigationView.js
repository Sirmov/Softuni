import { html } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (isLogged) =>
    html`<nav>
        <img src="./images/headphones.png" />
        <a href="/">Home</a>
        <ul>
            <!--All user-->
            <li><a href="/catalog">Catalog</a></li>
            <li><a href="/search">Search</a></li>
            ${isLogged
                ? html`<!--Only user-->
                      <li><a href="/create">Create Album</a></li>
                      <li><a href="/logout">Logout</a></li>`
                : html`<!--Only guest-->
                      <li><a href="/login">Login</a></li>
                      <li><a href="/register">Register</a></li>`}
        </ul>
    </nav>`;
