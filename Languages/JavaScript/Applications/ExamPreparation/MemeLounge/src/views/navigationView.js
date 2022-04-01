import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const navigationTemplate = (email, onLogout) =>
    html`<a href="/all-memes">All Memes</a>
        ${email
            ? html`<!-- Logged users -->
                  <div class="user">
                      <a href="/create">Create Meme</a>
                      <div class="profile">
                          <span>Welcome, ${email}</span>
                          <a href="/profile">My Profile</a>
                          <a href="javascript:void(0)" @click=${onLogout}>Logout</a>
                      </div>
                  </div>`
            : html`<!-- Guest users -->
                  <div class="guest">
                      <div class="profile">
                          <a href="/login">Login</a>
                          <a href="/register">Register</a>
                      </div>
                      <a class="active" href="/">Home Page</a>
                  </div>`}`;
