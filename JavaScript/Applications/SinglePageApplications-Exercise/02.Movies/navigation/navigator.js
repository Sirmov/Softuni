// Module handling navigation
import { getUserData } from '../auth/authentication.js';
import { route } from './router.js'

const navigationElement = document.querySelector('nav');
const clientNavigationList = navigationElement.querySelector('ul');
const userNavigation = navigationElement.querySelector('div.user');
const welcomeMessage = userNavigation.querySelector('#welcomeMessage');
const guestNavigation = navigationElement.querySelector('div.guest');
navigationElement.addEventListener('click', navigate);
clientNavigationList.replaceChildren();

function navigate(event) {
    event.preventDefault();

    if (event.target.tagName === 'A' && event.target.href) {
        const url = new URL(event.target.href);
        route(url.pathname);
    }
}

export function updateNav() {
    let userData = getUserData();

    if (userData) {
        welcomeMessage.textContent = `Welcome, ${userData.email}`;
        clientNavigationList.replaceChildren(userNavigation);
    } else {
        clientNavigationList.replaceChildren(guestNavigation);
    }
}
