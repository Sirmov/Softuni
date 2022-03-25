import { createComment, readComments } from '../services/commentsService.js';
import { getGame } from '../services/gamesService.js';
import { getUserId, isLogged } from '../utils/auth.js';
import { detailsTemplate } from '../views/detailsView.js';

export async function detailsController(ctx, next) {
    let game = await getGame(ctx.params.id);
    let comments = await readComments(game._id);
    let isOwner = getUserId() === game._ownerId;

    ctx.render(detailsTemplate(game, comments, commentSubmit, isOwner, isLogged()));

    async function commentSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let comment = formData.get('comment');

        if (comment) {
            await createComment(comment, ctx.params.id);
            event.target.reset();
            ctx.page.redirect(`/details/${ctx.params.id}`);
        } else {
            alert('Empty fields!');
        }
    }
}
