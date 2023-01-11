import { lit } from '../lib.js';
import { loading } from '../utils.js';

export const navigationTemplate = (isLoggedIn, username, pathname) =>
    lit.html`<nav>
                <a class="active" href="/">Home</a>
                <a href="/listings">All Listings</a>
                <a href="/by-year">By Year</a>
                ${
                    isLoggedIn
                        ? lit.html`<div id="profile">
                                <a>Welcome ${username}</a>
                                <a href="/my-listings">My Listings</a>
                                <a href="/create">Create Listing</a>
                                <a href="/logout">Logout</a>
                            </div>`
                        : lit.html`<div id="guest">
                                <a href="/login">Login</a>
                                <a href="/register">Register</a>
                            </div>`
                }
            </nav>`;
