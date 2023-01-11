import { initHome } from "./pages/home.js";
import { showView } from "./utils.js";

const homeView = document.querySelector('div.container');
const navigationElement = document.querySelector('header nav');

const routes = {
    '/home': homeView
};

navigationElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target.tagName === 'A') {
        let url = new URL(e.target.href);
        let view = routes[url.pathname] || alert.bind(null, 'Error 404!');

        if (typeof view === 'function') {
            view();
            return;
        }

        showView(view);
    }
})

initHome();
