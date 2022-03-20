import { logout } from '../api/request.js';

export async function renderLogout(ctx, next) {
    await logout();
    alert('Successful logout!');
    ctx.updateNav();
    ctx.page.redirect('/login');
}
