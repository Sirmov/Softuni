import { readMeme, updateMeme } from '../services/memesService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { editTemplate, formTemplate } from '../views/editView.js';

const allowedData = ['title', 'description', 'imageUrl'];

export function editController(ctx, next) {
    ctx.render(editTemplate(renderForm(ctx)));
}

async function renderForm(ctx) {
    let meme = await readMeme(ctx.params.id);

    return formTemplate(meme, createSubmitHandler(ctx, editSubmit, allowedData));
}

async function editSubmit(ctx, data, event) {
    await updateMeme(ctx.params.id, data);
    event.target.reset();
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
