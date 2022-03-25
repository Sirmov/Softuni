import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const editTemplate = (editSubmit, game) =>
    html`<section id="edit-page" class="auth">
        <form id="edit" @submit=${editSubmit}>
            <div class="container">
                <h1>Edit Game</h1>
                <label for="leg-title">Legendary title:</label>
                <input type="text" id="title" name="title" value=${game.title} />

                <label for="category">Category:</label>
                <input type="text" id="category" name="category" value=${game.category} />

                <label for="levels">MaxLevel:</label>
                <input type="number" id="maxLevel" name="maxLevel" min="1" value=${game.maxLevel} />

                <label for="game-img">Image:</label>
                <input type="text" id="imageUrl" name="imageUrl" value=${game.imageUrl} />

                <label for="summary">Summary:</label>
                <textarea name="summary" id="summary">${game.summary}</textarea>
                <input class="btn submit" type="submit" value="Edit Game" />
            </div>
        </form>
    </section>`;
