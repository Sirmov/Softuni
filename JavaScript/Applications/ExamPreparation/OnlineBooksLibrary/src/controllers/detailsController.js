import { readBook } from '../services/booksService.js';
import { readBookLikes, readUserLike } from '../services/likesService.js';
import { getUserId, isLogged } from '../utils/auth.js';
import { bookTemplate, detailsTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderBook(ctx)));
}

async function renderBook(ctx) {
    let [book, totalLikes] = await Promise.all([
        readBook(ctx.params.id),
        readBookLikes(ctx.params.id)
    ]);

    let isLiked;

    if (isLogged()) {
        isLiked = await readUserLike(getUserId(), ctx.params.id);
    }
    
    let isOwner = getUserId() === book._ownerId;

    return bookTemplate(book, isLogged(), isOwner, isLiked, totalLikes);
}
