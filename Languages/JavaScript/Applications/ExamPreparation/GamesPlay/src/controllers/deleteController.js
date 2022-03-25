import { deleteGame } from '../services/gamesService.js';

export async function deleteController(ctx, next) {
    let choice = confirm('Are you sure you want to delete this game?');

    if (choice) {
        await deleteGame(ctx.params.id);
        ctx.page.redirect('/');
    }
}
