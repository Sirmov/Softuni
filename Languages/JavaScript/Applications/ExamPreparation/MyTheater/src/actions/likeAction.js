import { createLike } from '../services/likesService.js';

export async function likeAction(ctx, event) {
    await createLike(ctx.params.id);
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
