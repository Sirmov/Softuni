import { createTheater } from '../services/theatersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['title', 'date', 'author', 'description', 'imageUrl'];

export function createController(ctx, next) {
    ctx.render(createTemplate(createSubmitHandler(ctx, createSubmit, allowedData)));
}

async function createSubmit(ctx, data, event) {
    await createTheater(data);
    event.target.reset();
    ctx.page.redirect('/');
}
