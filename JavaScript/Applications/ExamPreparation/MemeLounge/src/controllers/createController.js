import { createMeme } from '../services/memesService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['title', 'description', 'imageUrl'];

export function createController(ctx, next) {
    ctx.render(createTemplate(createSubmitHandler(ctx, createSubmit, allowedData)));
}

async function createSubmit(ctx, data, event) {
    await createMeme(data);
    event.target.reset();
    ctx.page.redirect('/all-memes');
}
