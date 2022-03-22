import { lit } from '../lib.js';
import { loading, spinner } from '../utils.js';

export const listingsTemplate = (carsPromise, isMyListings) =>
    lit.html`<section id=${isMyListings ? 'my-listings' : 'car-listings'}>
        ${isMyListings ? lit.html`<h1>My car listings</h1>` : lit.html`<h1>Car Listings</h1>`}
    <div class="listings">
        ${lit.until(carsPromise, spinner)}
    </div>
</section>`;

export const listingTemplate = (listings, isMyListings) =>
    lit.html`${
        listings.length > 0
            ? lit.html`${lit.repeat(
                  listings,
                  (listing) => listing._id,
                  (listing, index) => carTemplate(listing)
              )}`
            : isMyListings
            ? lit.html`<p class="no-cars"> You haven't listed any cars yet.</p>`
            : lit.html`<p class="no-cars">No cars in database.</p>`
    }`;

const carTemplate = (car) =>
    lit.html`<div class="listing">
            <div class="preview">
                <img src=${car.imageUrl}>
            </div>
            <h2>${`${car.brand} ${car.model}`}</h2>
            <div class="info">
                <div class="data-info">
                    <h3>Year: ${car.year}</h3>
                    <h3>Price: ${car.price} $</h3>
                </div>
                <div class="data-buttons">
                    <a href="/details/${car._id}" class="button-carDetails">Details</a>
                </div>
            </div>
        </div>`;
