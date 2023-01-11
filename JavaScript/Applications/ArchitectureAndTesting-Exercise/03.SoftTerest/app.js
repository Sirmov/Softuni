// Application entry point

// Import router and navigator
import { initialize } from './navigation/router.js';
import * as navigator from './navigation/navigator.js';
// Import views render logic
import { renderHome } from './views/home.js';
import { renderRegister } from './views/register.js';
import { renderLogin } from './views/login.js';
import { renderLogout } from './views/logout.js';
import { renderDashboard } from './views/dashboard.js';
import { renderCreate } from './views/create.js';
import { renderIdea } from './views/idea.js';

// Select root element
const viewContainer = document.getElementById('root');
viewContainer.replaceChildren();

// Links to view association
const links = {
    '/': 'home',
    '/dashboard': 'dashboard',
    '/create': 'create',
    '/idea': 'idea',
    '/login': 'login',
    '/register': 'register',
    '/logout': 'logout'
};
// View to render function association
const views = {
    home: renderHome,
    dashboard: renderDashboard,
    create: renderCreate,
    idea: renderIdea,
    login: renderLogin,
    register: renderRegister,
    logout: renderLogout
};

navigator.updateNav();
const router = initialize(links, views);
await router.route('/');
