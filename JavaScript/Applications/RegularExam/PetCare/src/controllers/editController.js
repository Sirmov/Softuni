import { readPet, updatePet } from '../services/petsService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { editTemplate, formTemplate } from '../views/editView.js';

const allowedData = ['name', 'breed', 'age', 'weight', 'image'];

export function editController(ctx, next) {
    ctx.render(editTemplate(renderForm(ctx)));
}

async function renderForm(ctx) {
    let pet = await readPet(ctx.params.id);

    return formTemplate(pet, createSubmitHandler(ctx, editSubmit, allowedData));
}

async function editSubmit(ctx, data, event) {
    console.log(data);
    await updatePet(ctx.params.id, data);
    event.target.reset();
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
