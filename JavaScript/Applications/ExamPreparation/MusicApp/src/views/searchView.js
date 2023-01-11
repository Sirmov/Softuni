import { html, repeat, nothing, until } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const searchTemplate = (search, resultsPromise) =>
    html`<section id="searchPage">
        <h1>Search by Name</h1>

        <div class="search">
            <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name" />
            <button class="button-list" @click=${search}>Search</button>
        </div>
        ${resultsPromise ? until(resultsPromise, spinner) : nothing}
    </section>`;

export const resultsTemplate = (albums, isLogged) =>
    html`<!--Show after click Search button-->
        <h2>Results:</h2>
        <div class="search-result">
            ${albums.length === 0
                ? html`<!--If there are no matches-->
                      <p class="no-result">No result.</p>`
                : html`<!--If have matches-->
                      ${repeat(
                          albums,
                          (album) => album._id,
                          (album, index) => albumTemplate(album, isLogged)
                      )}`}
        </div>`;

const albumTemplate = (album, isLogged) =>
    html` <div class="card-box">
        <img src=${album.imgUrl} />
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: $${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            ${isLogged
                ? html`<div class="btn-group">
                      <a href="/details/${album._id}" id="details">Details</a>
                  </div>`
                : nothing}
        </div>
    </div>`;
