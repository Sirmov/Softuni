// Application entry point

// Import page, lit-html and updateNav
import { page } from './lib.js';
import { html, render, nothing, repeat, until } from './lib.js';
import { setActive, updateNav } from './navigation/navigator.js';

// Import views render logic
import { renderDashboard } from './views/dashboard.js';
import { renderLogin } from './views/login.js';
import { renderRegister } from './views/register.js';
import { renderLogout } from './views/logout.js';
import { renderFurnitureDetails } from './views/details.js';
import { renderCreatFurniture } from './views/create.js';
import { renderEditFurniture } from './views/edit.js';

// Select root element
const viewContainer = document.getElementById('view-container');

// Register routes
page(decorateContext);
page('/', renderDashboard);
page('/dashboard', renderDashboard);
page('/my-furniture', renderDashboard);
page('/create-furniture', renderCreatFurniture);
page('/furniture/:id', renderFurnitureDetails);
page('/edit/:id', renderEditFurniture);
page('/login', renderLogin);
page('/register', renderRegister);
page('/logout', renderLogout);

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, viewContainer);
    ctx.html = html;
    ctx.nothing = nothing;
    ctx.repeat = repeat;
    ctx.until = until;
    ctx.updateNav = updateNav;
    ctx.setActive = () => setActive(ctx);

    next();
}

page.start();
updateNav();
