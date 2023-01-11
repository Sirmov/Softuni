import { readAllPets } from '../services/petsService.js';
import { dashboardTemplate, petsTemplate } from '../views/dashboardView.js';

export function dashboardController(ctx, next) {
    ctx.render(dashboardTemplate(renderPets()));
}

async function renderPets() {
    let pets = await readAllPets();

    return petsTemplate(pets);
}
