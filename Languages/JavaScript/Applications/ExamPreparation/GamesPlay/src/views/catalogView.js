import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const catalogTemplate = (gamesPromise) =>
html`<section id="catalog-page">
        <h1>All Games</h1>
        <!-- Display div: with information about every game (if any) -->
        ${until(gamesPromise, loading)}
    </section>`;

export const gamesTemplate = (games) =>
    html`${games.length === 0
        ? html`<!-- Display paragraph: If there is no games  -->
              <h3 class="no-articles">No articles yet</h3>`
        : html`${repeat(
              games,
              (game) => game._id,
              (game, index) => gameTemplate(game)
          )}`}`;

const gameTemplate = (game) =>
    html`<div class="allGames">
        <div class="allGames-info">
            <img src=${game.imageUrl} />
            <h6>${game.category}</h6>
            <h2>${game.title}</h2>
            <a href="/details/${game._id}" class="details-button">Details</a>
        </div>
    </div>`;
