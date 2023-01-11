import { lit } from '../lib.js';
import { loading } from '../utils.js';

export const byYearTemplate = (search, listings) =>
    lit.html`<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${search}>Search</button>
    </div>

    ${listings ? listings : lit.nothing}
</section>`;

export const listingsTemplate = (listings) =>
    lit.html`
    <h2>Results:</h2>
    <div class="listings">
    ${
        listings.length > 0
            ? lit.html`${listings.map(carTemplate)}`
            : lit.html`<p class="no-cars"> No results.</p>`
    }
    </div>`;

const carTemplate = (car) =>
    lit.html`<div class="listing">
        <div class="preview">
            <img src=${car.imageUrl}>
        </div>
        <h2>${car.brand} ${car.model}</h2>
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
