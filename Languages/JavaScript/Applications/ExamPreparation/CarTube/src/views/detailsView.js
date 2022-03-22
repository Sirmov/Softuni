import { lit } from '../lib.js';
import { spinner } from '../utils.js';

export const detailsTemplate = (listingPromise) =>
    lit.html`<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        ${lit.until(listingPromise, spinner)}
    </div>
</section>`;

export const listingTemplate = (listing, isOwner) =>
    lit.html`<img src=${listing.imageUrl}>
            <hr>
            <ul class="listing-props">
                <li><span>Brand:</span>${listing.brand}</li>
                <li><span>Model:</span>${listing.model}</li>
                <li><span>Year:</span>${listing.year}</li>
                <li><span>Price:</span>${listing.price}$</li>
            </ul>

            <p class="description-para">${listing.description}</p>
            ${
                isOwner
                    ? lit.html`<div class="listings-buttons">
                        <a href="/edit/${listing._id}" class="button-list">Edit</a>
                        <a href="/delete/${listing._id}" class="button-list">Delete</a>
                    </div>`
                    : lit.nothing
            }`;
