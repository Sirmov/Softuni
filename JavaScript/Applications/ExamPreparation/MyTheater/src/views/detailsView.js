import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = (eventPromise) =>
    html`<section id="detailsPage">${until(eventPromise, spinner)}</section>`;

export const eventTemplate = (event, isOwner, onDelete, likePromise) =>
    html`<div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${event.title}</h1>
            <div>
                <img src=${event.imageUrl} />
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${event.description}</p>
            <h4>Date: ${event.date}</h4>
            <h4>Author: ${event.author}</h4>
            <div class="buttons">
                ${isOwner
                    ? html`<a class="btn-delete" href="javascript:void(0)" @click=${onDelete}>Delete</a>
                          <a class="btn-edit" href="/edit/${event._id}">Edit</a>`
                    : nothing}
                ${until(likePromise, spinner)}
            </div>

            <p class="likes">Likes: ${event.likes}</p>
        </div>
    </div>`;

export const likeTemplate = (isLogged, isOwner, isLiked, onLike) =>
    html`${isLogged
        ? !isOwner && !isLiked
            ? html`<a class="btn-like" href="javascript:void(0)" @click=${onLike}>Like</a>`
            : nothing
        : nothing}`;
