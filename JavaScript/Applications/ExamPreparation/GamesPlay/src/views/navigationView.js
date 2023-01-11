import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (isLogged) =>
    html`<!-- Navigation -->
        <h1><a class="home" href="/">GamesPlay</a></h1>
        <nav>
            <a href="/catalog">All games</a>
            ${isLogged
                ? html`<!-- Logged-in users -->
                      <div id="user">
                          <a href="/create">Create Game</a>
                          <a href="/logout">Logout</a>
                      </div>`
                : html`<!-- Guest users -->
                      <div id="guest">
                          <a href="/login">Login</a>
                          <a href="/register">Register</a>
                      </div>`}
        </nav>`;
