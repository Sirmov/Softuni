import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = (gamePromise, commentsPromise, actionsPromise) =>
    html`<section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
            ${until(gamePromise, nothing)} 
            ${until(commentsPromise, nothing)}
            ${until(actionsPromise, nothing)}
        </div>
    </section>`;

export const gameTemplate = (game) =>
    html`<div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">${game.summary}</p>`;

const commentFormTemplate = (commentSubmit) =>
    html` <!-- Bonus -->
        <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
        <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form" @submit=${commentSubmit}>
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment" />
            </form>
        </article>`;

const commentTemplate = (comment) =>
    html`<li class="comment">
        <p>${comment.comment}</p>
    </li>`;

export const commentsTemplate = (comments) =>
    html` <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            ${comments.length > 0
                ? html` <ul>
                      <!-- list all comments for current game (If any) -->
                      ${repeat(
                          comments,
                          (comment) => comment._id,
                          (comment, index) => commentTemplate(comment)
                      )}
                  </ul>`
                : html`<!-- Display paragraph: If there are no games in the database -->
                      <p class="no-comment">No comments.</p>`}
        </div>`;

export const actionsTemplate = (commentSubmit, isLogged, isOwner, gameId) => 
html`${isOwner
    ? html`<!-- Edit/Delete buttons ( Only for creator of this game )  -->
          <div class="buttons">
              <a href="/edit/${gameId}" class="button">Edit</a>
              <a href="/delete/${gameId}" class="button">Delete</a>
          </div>`
    : nothing}
${isLogged && !isOwner ? commentFormTemplate(commentSubmit) : nothing}`;
