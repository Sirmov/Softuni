// Module handling navigation

import { getUserData } from '../auth/authentication.js';
import { route } from './router.js';

// Selects all navigation element and adds events
const navigationElement = document.querySelector('nav');
const clientNavigationList = navigationElement.querySelector('ul');
const userNavigation = clientNavigationList.querySelector('div.user');
const guestNavigation = clientNavigationList.querySelector('div.guest');
userNavigation.style.display = 'flex';
guestNavigation.style.display = 'flex';
navigationElement.addEventListener('click', navigate);
clientNavigationList.replaceChildren();

// Handles event delegation
function navigate(event) {
    event.preventDefault();

    if (event.target.tagName === 'A' && event.target.href) {
        const url = new URL(event.target.href);
        route(url.pathname);
    } else if (event.target.tagName === 'IMG') {
        const url = new URL(event.target.parentElement.href);
        route(url.pathname);
    }
}

// Updates nav and welcome message
export function updateNav() {
    let userData = getUserData();

    if (userData) {
        clientNavigationList.replaceChildren(userNavigation);
    } else {
        clientNavigationList.replaceChildren(guestNavigation);
    }
}
