import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = () =>
    html`<section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
            <div class="game-header">
                <img class="game-img" src="images/MineCraft.png" />
                <h1>Bright</h1>
                <span class="levels">MaxLevel: 4</span>
                <p class="type">Action, Crime, Fantasy</p>
            </div>

            <p class="text">
                Set in a world where fantasy creatures live side by side with humans. A human cop is forced to work with
                an Orc to find a weapon everyone is prepared to kill for. Set in a world where fantasy creatures live
                side by side with humans. A human cop is forced to work with an Orc to find a weapon everyone is
                prepared to kill for.
            </p>

            <!-- Bonus ( for Guests and Users ) -->
            <div class="details-comments">
                <h2>Comments:</h2>
                <ul>
                    <!-- list all comments for current game (If any) -->
                    <li class="comment">
                        <p>Content: I rate this one quite highly.</p>
                    </li>
                    <li class="comment">
                        <p>Content: The best game.</p>
                    </li>
                </ul>
                <!-- Display paragraph: If there are no games in the database -->
                <p class="no-comment">No comments.</p>
            </div>

            <!-- Edit/Delete buttons ( Only for creator of this game )  -->
            <div class="buttons">
                <a href="#" class="button">Edit</a>
                <a href="#" class="button">Delete</a>
            </div>
        </div>

        <!-- Bonus -->
        <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
        <article class="create-comment">
            <label>Add new comment:</label>
            <form class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment" />
            </form>
        </article>
    </section>`;
