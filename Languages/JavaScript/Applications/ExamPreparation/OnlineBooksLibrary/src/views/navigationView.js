import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (email) =>
    html`<nav class="navbar">
        <section class="navbar-dashboard">
            <a href="/">Dashboard</a>
            ${email
                ? html`<!-- Logged-in users -->
                      <div id="user">
                          <span>Welcome, ${email}</span>
                          <a class="button" href="/my-books">My Books</a>
                          <a class="button" href="/add-book">Add Book</a>
                          <a class="button" href="/logout">Logout</a>
                      </div>`
                : html`<!-- Guest users -->
                      <div id="guest">
                          <a class="button" href="/login">Login</a>
                          <a class="button" href="/register">Register</a>
                      </div>`}
        </section>
    </nav>`;
