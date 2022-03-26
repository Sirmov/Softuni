import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = (bookPromise) =>
    html`<section id="details-page" class="details">${until(bookPromise, spinner)}</section>`;

export const bookTemplate = (book, isLogged, isOwner, isLiked, totalLikes) =>
    html`<div class="book-information">
            <h3>${book.title}</h3>
            <p class="type">Type: ${book.type}</p>
            <p class="img"><img src=${book.imageUrl} /></p>
            <div class="actions">
                ${isOwner
                    ? html`<!-- Edit/Delete buttons ( Only for creator of this book )  -->
                          <a class="button" href="/edit/${book._id}">Edit</a>
                          <a class="button" href="/delete/${book._id}">Delete</a>`
                    : nothing}
                <!-- Bonus -->

                ${isLogged && !isOwner && !isLiked
                    ? html`<!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
                          <a class="button" href="/like/${book._id}">Like</a>`
                    : nothing}

                <!-- ( for Guests and Users )  -->
                <div class="likes">
                    <img class="hearts" src="/images/heart.png" />
                    <span id="total-likes">Likes: ${totalLikes}</span>
                </div>
                <!-- Bonus -->
            </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${book.description}</p>
        </div>`;
