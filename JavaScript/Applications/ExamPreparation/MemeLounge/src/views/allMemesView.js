import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const allMemesTemplate = (memesPromise) =>
    html`<!-- All Memes Page ( for Guests and Users )-->
        <section id="meme-feed">
            <h1>All Memes</h1>
            <div id="memes">${until(memesPromise, spinner)}</div>
        </section>`;

export const memesTemplate = (memes) =>
    html`${memes.length > 0
        ? html`<!-- Display : All memes in database ( If any ) -->
              ${repeat(
                  memes,
                  (meme) => meme._id,
                  (meme, index) => memeTemplate(meme)
              )}`
        : html`<!-- Display : If there are no memes in database -->
              <p class="no-memes">No memes in database.</p>`}`;

const memeTemplate = (meme) =>
    html`<div class="meme">
        <div class="card">
            <div class="info">
                <p class="meme-title">${meme.title}</p>
                <img class="meme-image" alt="meme-img" src=${meme.imageUrl} />
            </div>
            <div id="data-buttons">
                <a class="button" href="/details/${meme._id}">Details</a>
            </div>
        </div>
    </div>`;
