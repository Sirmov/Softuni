import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = (memePromise) =>
    html`<!-- Details Meme Page (for guests and logged users) -->
        <section id="meme-details">${until(memePromise, spinner)}</section>`;

export const memeTemplate = (meme, onDelete) =>
    html`<h1>Meme Title: ${meme.title}</h1>
        <div class="meme-details">
            <div class="meme-img">
                <img alt="meme-alt" src=${meme.imageUrl} />
            </div>
            <div class="meme-description">
                <h2>Meme Description</h2>
                <p>${meme.description}</p>

                ${meme.isOwner
                    ? html`<!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
                          <a class="button warning" href="/edit/${meme._id}">Edit</a>
                          <button class="button danger" @click=${onDelete}>Delete</button>`
                    : nothing}
            </div>
        </div>`;
