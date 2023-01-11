import { createComment, readComments } from '../services/commentsService.js';
import { getGame } from '../services/gamesService.js';
import { getUserId, isLogged } from '../utils/auth.js';
import { actionsTemplate, commentsTemplate, detailsTemplate, gameTemplate } from '../views/detailsView.js';

export async function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderGame(), renderComments(), renderActions()));

    async function renderActions() {
        let game = await getGame(ctx.params.id);
        let isOwner = getUserId() === game._ownerId;

        return actionsTemplate(commentSubmit, isLogged(), isOwner, game._id);
    }

    async function renderGame() {
        let game = await getGame(ctx.params.id);

        return gameTemplate(game);
    }

    async function renderComments() {
        let comments = await readComments(ctx.params.id);

        return commentsTemplate(comments);
    }

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
