import { homeTemplate } from '../views/homeView.js';

export function homeController(ctx, next) {
    ctx.render(homeTemplate());
}
