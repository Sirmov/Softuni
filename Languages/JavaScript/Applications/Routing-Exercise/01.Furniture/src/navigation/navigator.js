// Module handling navigation

import { isLoggedIn } from '../auth/authentication.js';
import { render } from '../lib.js';
import { navigationTemplate } from '../templates.js';

// Selects all navigation element and adds events
const navigationContainer = document.querySelector('header');

// Updates nav
export function updateNav() {
    render(navigationTemplate(isLoggedIn()), navigationContainer);
}

export function setActive(ctx) {
    let linkElements = navigationContainer.querySelectorAll('a');
    linkElements.forEach((element) => {
        element.classList.remove('active');
        let url = new URL(element.href);
        let current = ctx.page.current === '/' ? '/dashboard' : ctx.page.current;

        if (url.pathname === current && element.id) {
            element.classList.add('active');
        }
    });
}
