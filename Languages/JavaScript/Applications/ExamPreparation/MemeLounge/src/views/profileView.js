import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const profileTemplate = (memesPromise) =>
    html`<!-- Profile Page ( Only for logged users ) -->
        <section id="user-profile-page" class="user-profile">${until(memesPromise, spinner)}</section>`;

export const memesTemplate = (memes, user) =>
    html`<article class="user-info">
            <img id="user-avatar-url" alt="user-profile" src="/images/female.png" />
            <div class="user-content">
                <p>Username: ${user.username}</p>
                <p>Email: ${user.email}</p>
                <p>My memes count: ${memes.length}</p>
            </div>
        </article>
        <h1 id="user-listings-title">User Memes</h1>
        <div class="user-meme-listings">
            ${memes.length > 0
                ? html`<!-- Display : All created memes by this user (If any) -->
                      ${repeat(
                          memes,
                          (meme) => meme._id,
                          (meme, index) => memeTemplate(meme)
                      )}`
                : html`<!-- Display : If user doesn't have own memes  -->
                      <p class="no-memes">No memes in database.</p>`}
        </div>`;

const memeTemplate = (meme) =>
    html`<div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl} />
        <a class="button" href="/details/${meme._id}">Details</a>
    </div>`;
