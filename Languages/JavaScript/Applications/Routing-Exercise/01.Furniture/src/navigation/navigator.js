// Module handling navigation

import { getUserData } from '../auth/authentication.js';
import { route } from './router.js';

// Selects all navigation element and adds events
const navigationElement = document.querySelector('nav');
const clientNavigationList = navigationElement.querySelector('ul');
const userNavigation = navigationElement.querySelector('div.user');
const guestNavigation = navigationElement.querySelector('div.guest');
navigationElement.addEventListener('click', navigate);
clientNavigationList.replaceChildren();

// Handles event delegation
function navigate(event) {
    event.preventDefault();

    if (event.target.tagName === 'A' && event.target.href) {
        const url = new URL(event.target.href);
        route(url.pathname);
    }
}

// Updates nav
export function updateNav() {
    let userData = getUserData();

    if (userData) {
        clientNavigationList.replaceChildren(userNavigation);
    } else {
        clientNavigationList.replaceChildren(guestNavigation);
    }
}
