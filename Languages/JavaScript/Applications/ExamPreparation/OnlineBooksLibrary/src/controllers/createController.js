import { createBook } from '../services/booksService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['title', 'description', 'imageUrl', 'type'];

export function createController(ctx, next) {
    ctx.render(createTemplate(createSubmitHandler(ctx, createSubmit, allowedData)));
}

async function createSubmit(ctx, data, event) {
    await createBook(data);
    event.target.reset();
    ctx.page.redirect('/');
}
