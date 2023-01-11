import { getAllGames } from '../services/gamesService.js';
import { catalogTemplate, gamesTemplate } from '../views/catalogView.js';

export function catalogController(ctx, next) {
    ctx.render(catalogTemplate(renderGames()));

    async function renderGames() {
        let games = await getAllGames();

        return gamesTemplate(games);
    }
}
