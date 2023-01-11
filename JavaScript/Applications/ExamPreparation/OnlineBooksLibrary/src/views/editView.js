import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const editTemplate = (formPromise) =>
    html`<section id="edit-page" class="edit">${until(formPromise, spinner)}</section>`;

export const formTemplate = (editSubmit, book) =>
    html`<form id="edit-form" @submit=${editSubmit} action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" value=${book.title} />
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" value=${book.imageUrl} />
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" value="Fiction">
                        <option value="Fiction" ?selected=${book.type === 'Fiction'}>Fiction</option>
                        <option value="Romance" ?selected=${book.type === 'Romance'}>Romance</option>
                        <option value="Mistery" ?selected=${book.type === 'Mistery'}>Mistery</option>
                        <option value="Classic" ?selected=${book.type === 'Classic'}>Clasic</option>
                        <option value="Other" ?selected=${book.type === 'Other'}>Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save" />
        </fieldset>
    </form>`;
