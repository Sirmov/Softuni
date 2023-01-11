import { createPet } from '../services/petsService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['name', 'breed', 'age', 'weight', 'image'];

export function createController(ctx, next) {
    ctx.render(createTemplate(createSubmitHandler(ctx, createSubmit, allowedData)));
}

async function createSubmit(ctx, data, event) {
    await createPet(data);
    event.target.reset();
    ctx.page.redirect('/');
}
