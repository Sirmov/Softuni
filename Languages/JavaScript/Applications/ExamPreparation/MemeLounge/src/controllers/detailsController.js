import { deleteAction } from '../actions/deleteAction.js';
import { readMeme } from '../services/memesService.js';
import { getUserId } from '../utils/auth.js';
import { createEventHandler } from '../utils/handler.js';
import { detailsTemplate, memeTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderMeme(ctx)));
}

async function renderMeme(ctx) {
    let meme = await readMeme(ctx.params.id);
    meme.isOwner = getUserId() === meme._ownerId;

    return memeTemplate(meme, createEventHandler(ctx, deleteAction));
}
