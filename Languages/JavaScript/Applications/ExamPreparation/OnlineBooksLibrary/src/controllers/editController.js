import { readBook, updateBook } from '../services/booksService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { editTemplate, formTemplate } from '../views/editView.js';

const allowedData = ['title', 'description', 'imageUrl', 'type'];

export function editController(ctx, next) {
    ctx.render(editTemplate(renderForm(ctx)));
}

async function renderForm(ctx) {
    let book = await readBook(ctx.params.id);

    return formTemplate(createSubmitHandler(ctx, editSubmit, allowedData), book);
}

async function editSubmit(ctx, data, event) {
    await updateBook(ctx.params.id, data);
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
