import { createLike } from '../services/likesService.js';

export async function likeBookAction(ctx, next) {
    await createLike(ctx.params.id);
    ctx.page.redirect(`/details/${ctx.params.id}`);
}
