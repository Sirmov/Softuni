import { renderHome } from './pages/home.js';
import { renderLogin } from './pages/login.js';
import { renderLogout } from './pages/logout.js';
import { renderRegister } from './pages/register.js';

const viewsSection = document.getElementById('views')

const routes = {
    '/': renderHome,
    '/login': renderLogin,
    '/register': renderRegister,
    '/logout': renderLogout
}

export function route(path) {
    hideViews();

    let pageRenderer = routes[path];

    if (pageRenderer) {
        pageRenderer();
    }
}

function hideViews() {
    for (const element of viewsSection.children) {
        element.style.display = 'none';
    }
}
