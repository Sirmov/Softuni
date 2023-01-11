import { deleteAction } from '../actions/deleteAction.js';
import { donateAction } from '../actions/donateAction.js';
import { readPetDonations, readUserDonations } from '../services/dontaionsService.js';
import { readPet } from '../services/petsService.js';
import { getUserId, isLogged } from '../utils/auth.js';
import { createEventHandler } from '../utils/handler.js';
import { detailsTemplate, petTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderPet(ctx)));
}

async function renderPet(ctx) {
    let [pet, donations] = await Promise.all([readPet(ctx.params.id), readPetDonations(ctx.params.id)]);
    pet.isLogged = isLogged();
    pet.isOwner = getUserId() === pet._ownerId;

    if (pet.isLogged) {
        pet.hasDonated = await readUserDonations(ctx.params.id, getUserId());
    }

    return petTemplate(pet, donations, createEventHandler(ctx, deleteAction), createEventHandler(ctx, donateAction));
}
