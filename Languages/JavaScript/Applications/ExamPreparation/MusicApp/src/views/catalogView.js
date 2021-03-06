import { html, until, repeat, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const catalogTemplate = (albumsPromise) =>
    html`<section id="catalogPage">
        <h1>All Albums</h1>
        ${until(albumsPromise, spinner)}
    </section>`;

export const albumsTemplate = (albums, isLogged) =>
    html`${albums.length === 0
        ? html`<!--No albums in catalog-->
              <p>No Albums in Catalog!</p>`
        : html`<!-- Albums -->
              ${repeat(
                  albums,
                  (album) => album._id,
                  (album, index) => albumTemplate(album, isLogged)
              )}`}`;

const albumTemplate = (album, isLogged) =>
    html`<div class="card-box">
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
