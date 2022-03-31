import { deleteAction } from '../actions/deleteAction.js';
import { likeAction } from '../actions/likeAction.js';
import { readTheaterLikes, readUserLike } from '../services/likesService.js';
import { readTheater } from '../services/theatersService.js';
import { getUserId, isLogged } from '../utils/auth.js';
import { createEventHandler } from '../utils/handler.js';
import { detailsTemplate, eventTemplate, likeTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderEvent(ctx)));
}

async function renderEvent(ctx) {
    let [event, likes] = await Promise.all([readTheater(ctx.params.id), readTheaterLikes(ctx.params.id)]);
    event.likes = likes;
    let isOwner = getUserId() === event._ownerId;

    return eventTemplate(event, isOwner, createEventHandler(ctx, deleteAction), renderLike(ctx, isOwner));
}

async function renderLike(ctx, isOwner) {
    let isLiked;

    if (isLogged()) {
        isLiked = await readUserLike(getUserId(), ctx.params.id);
    }
    
    return likeTemplate(isLogged(), isOwner, isLiked, createEventHandler(ctx, likeAction));
}
