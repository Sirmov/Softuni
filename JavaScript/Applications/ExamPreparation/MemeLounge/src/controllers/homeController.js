import { isLogged } from '../utils/auth.js';
import { homeTemplate } from '../views/homeView.js';

export function homeController(ctx, next) {
    if (isLogged()) {
        ctx.page.redirect('/all-memes');
    }
    
    ctx.render(homeTemplate());
}
