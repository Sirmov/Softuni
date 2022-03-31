import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const editTemplate = (formPromise) => html`<section id="editPage">${until(formPromise, spinner)}</section>`;

export const formTemplate = (event, editSubmit) =>
    html`<form class="theater-form" @submit=${editSubmit}>
        <h1>Edit Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" .value=${event.title} />
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year" .value=${event.date} />
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author" .value=${event.author} />
        </div>
        <div>
            <label for="description">Theater Description:</label>
            <textarea
                id="description"
                name="description"
                placeholder="Description"
                .value=${event.description}
            ></textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" .value=${event.imageUrl} />
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>`;
