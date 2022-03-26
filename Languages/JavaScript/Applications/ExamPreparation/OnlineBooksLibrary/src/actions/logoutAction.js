import { logout } from '../services/usersService.js';

export async function logoutAction(ctx, next) {
    await logout();
    ctx.page.redirect('/');
}
