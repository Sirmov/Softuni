import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const homeTemplate = (gamesPromise) =>
    html`<section id="welcome-world">
        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero" />

        <div id="home-page">
            <h1>Latest Games</h1>
            ${until(gamesPromise, loading)}
        </div>
    </section>`;

export const gamesTemplate = (games) =>
    html`${games.length > 0
        ? html`<!-- Display div: with information about every game (if any) -->
              ${repeat(
                  games,
                  (game) => game._id,
                  (game, index) => gameTemplate(game)
              )}`
        : html`<!-- Display paragraph: If there is no games  -->
              <p class="no-articles">No games yet</p>`}`;

const gameTemplate = (game) =>
    html`<div class="game">
        <div class="image-wrap">
            <img src=${game.imageUrl} />
        </div>
        <h3>${game.title}</h3>
        <div class="rating"><span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span></div>
        <div class="data-buttons">
            <a href="/details/${game._id}" class="btn details-btn">Details</a>
        </div>
    </div>`;
