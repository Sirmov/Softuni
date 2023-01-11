import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const createTemplate = (createSubmit) =>
    html`<!-- Create Meme Page ( Only for logged users ) -->
        <section id="create-meme">
            <form id="create-form" @submit=${createSubmit}>
                <div class="container">
                    <h1>Create Meme</h1>
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title" />
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description"></textarea>
                    <label for="imageUrl">Meme Image</label>
                    <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl" />
                    <input type="submit" class="registerbtn button" value="Create Meme" />
                </div>
            </form>
        </section>`;
