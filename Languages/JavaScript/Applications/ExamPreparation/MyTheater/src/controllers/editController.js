import { readTheater, updateTheater } from '../services/theatersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { editTemplate, formTemplate } from '../views/editView.js';

const allowedData = ['title', 'date', 'author', 'description', 'imageUrl'];

export function editController(ctx, next) {
    ctx.render(editTemplate(renderForm(ctx)));
}

async function renderForm(ctx) {
    let event = await readTheater(ctx.params.id);

    return formTemplate(event, createSubmitHandler(ctx, editSubmit, allowedData));
}

async function editSubmit(ctx, data, event) {
    await updateTheater(ctx.params.id, data);
    event.target.reset();
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
