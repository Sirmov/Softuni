import { logout } from '../services/usersService.js';

export async function logoutController(ctx, next) {
    await logout();
    ctx.page.redirect('/');
}
