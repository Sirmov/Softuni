// Module handling navigation
import { route } from './router.js'

const navigationElement = document.querySelector('nav');
navigationElement.addEventListener('click', navigate);

function navigate(event) {
    event.preventDefault();

    if (event.target.tagName === 'A' && event.target.href) {
        const url = new URL(event.target.href);
        route(url.pathname);
    }
}

export function updateNav() {

}
