import { logout } from '../api/request.js';
import { clearUserData } from '../auth/authentication.js';
import { updateNav } from '../navigation/navigator.js';
import { route } from '../navigation/router.js';

export async function renderLogout() {
    await logout();
    clearUserData();
    updateNav();
    await route('/');
}
