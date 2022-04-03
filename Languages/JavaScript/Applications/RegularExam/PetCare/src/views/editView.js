import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const editTemplate = (formPromise) =>
    html`<!--Edit Page-->
        <section id="editPage">${until(formPromise, nothing)}</section>`;

export const formTemplate = (pet, editSubmit) =>
    html`<form class="editForm" @submit=${editSubmit}>
        <img src=${pet.image} />
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" .value=${pet.name} />
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" .value=${pet.breed} />
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" .value=${pet.age} />
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" .value=${pet.weight} />
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" .value=${pet.image} />
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>`;
