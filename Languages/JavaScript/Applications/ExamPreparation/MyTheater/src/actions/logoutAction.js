import { logout } from '../services/usersService.js';

export async function logoutAction(ctx, event) {
    await logout();
    ctx.page.redirect('/');
}
