// Application entry point

// Import router and navigator
import { initialize } from "./navigation/router.js";
import * as navigator from "./navigation/navigator.js";
// Import views render logic
import { renderHome } from "./views/home.js"

// Select root element
const viewContainer = document.getElementById('views');
viewContainer.replaceChildren();

// Links to view association
const links = {
    '/': 'home'
}
// View to render function association
const views = {
    'home': renderHome
}

navigator.updateNav();
const router = initialize(links, views);
await router.route('/');
