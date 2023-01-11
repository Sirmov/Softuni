import { createPetDonations } from '../services/dontaionsService.js';

export async function donateAction(ctx, event) {
    await createPetDonations({ petId: ctx.params.id });
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
