import { getFurnitureDetails, updateFurniture } from '../api/request.js';
import { editFormTemplate, editFurnitureTemplate } from '../templates.js';

const allowedData = ['make', 'model', 'year', 'description', 'price', 'img', 'material'];

// Export render function
export function renderEditFurniture(ctx, next) {
    ctx.render(editFurnitureTemplate(renderEditForm()));

    async function renderEditForm() {
        let furniture = await getFurnitureDetails(ctx.params.id);
        return editFormTemplate(furniture, editSubmit);
    }

    async function editSubmit(event) {
        event.preventDefault();

        const formData = [...new FormData(event.target).entries()];
        const data = formData.reduce((a, [k, v]) => (allowedData.includes(k) ? Object.assign(a, { [k]: v }) : a), {});
        data.year = Number(data.year);
        data.price = Number(data.price);
        data._id = event.target.dataset.id;
        let error = {
            inputs: formData.reduce(
                (a, [k, v]) => (allowedData.includes(k) ? Object.assign(a, { [k]: false }) : a),
                {}
            ),
            messages: []
        };

        if (data.make.length < 4 || data.model.length < 4) {
            error.messages.push('Make and model should be at least 4 characters long!');
            error.inputs.make = data.make.length < 4;
            error.inputs.model = data.model.length < 4;
        }
        if (Number.isNaN(data.year) || data.year < 1950 || data.year > 2050) {
            error.messages.push('Year must be between 1950 and 2050!');
            error.inputs.year = true;
        }
        if (data.description.length <= 10) {
            error.messages.push('Description must be more than 10 characters!');
            error.inputs.description = true;
        }
        if (Number.isNaN(data.price) || data.price <= 0) {
            error.messages.push('Price must be a positive number!');
            error.inputs.price = true;
        }
        if (!data.img) {
            error.messages.push('Image is required!');
            error.inputs.img = true;
        }

        if (error.messages.length === 0) {
            await updateFurniture(event.target.dataset.id, data);
            alert('Successfully updated furniture!');
            event.target.reset();
            ctx.page.redirect(`/furniture/${event.target.dataset.id}`);
        } else {
            alert(error.messages.join(' '));
            ctx.render(editFurnitureTemplate(editFormTemplate(data, editSubmit, error.inputs)));
        }
    }
}
