import { lit } from '../lib.js';
import { loading } from '../utils.js';

export const editTemplate = (editSubmit, listing) =>
    lit.html`<section id="edit-listing">
    <div class="container">

        <form id="edit-form" @submit=${editSubmit}>
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value=${listing.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value=${listing.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value=${listing.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value=${listing.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value=${listing.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value=${listing.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;
