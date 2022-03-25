import { getRecentGames } from '../services/gamesService.js';
import { gamesTemplate, homeTemplate } from '../views/homeView.js';

export function homeController(ctx, next) {
    ctx.render(homeTemplate(renderGames()));

    async function renderGames() {
        let games = await getRecentGames();

        return gamesTemplate(games);
    }
}
