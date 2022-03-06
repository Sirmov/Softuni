import { authenticate } from './src/auth.js';
import { route } from './src/router.js'

const navigationElement = document.querySelector('header nav');

authenticate();
route('/');

navigationElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target.tagName === 'A') {
        let url = new URL(e.target.href);
        navigationElement.querySelector('.active').classList.remove('active');
        e.target.classList.add('active');
        route(url.pathname);
    }
});
