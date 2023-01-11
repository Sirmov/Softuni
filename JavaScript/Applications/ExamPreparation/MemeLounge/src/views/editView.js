import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const editTemplate = (formPromise) =>
    html`<!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
        <section id="edit-meme">${until(formPromise, spinner)}</section>`;

export const formTemplate = (meme, editSubmit) =>
    html`<form id="edit-form" @submit=${editSubmit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title} />
            <label for="description">Description</label>
            <textarea
                id="description"
                placeholder="Enter Description"
                name="description"
                .value=${meme.description}
            ></textarea>
            <label for="imageUrl">Image Url</label>
            <input
                id="imageUrl"
                type="text"
                placeholder="Enter Meme ImageUrl"
                name="imageUrl"
                .value=${meme.imageUrl}
            />
            <input type="submit" class="registerbtn button" value="Edit Meme" />
        </div>
    </form>`;
