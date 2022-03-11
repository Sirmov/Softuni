// Application entry point

import { initialize } from "./navigation/router.js";
import * as navigator from "./navigation/navigator.js";
import { renderHome } from "./views/home.js";
import { renderLogin } from "./views/login.js";
import { renderRegister } from "./views/register.js";
import { logout } from "./api/request.js";

// Select all views
const viewContainer = document.getElementById('views');
const addMovieView = document.querySelector('div.addMovie-view');
const movieView = document.querySelector('div.movie-view');
const editMovieView = document.querySelector('div.editMovie-view');
viewContainer.replaceChildren();

const links = {
    '/': 'home',
    '/addMovie': 'addMovie',
    '/movie': 'movie',
    '/editMovie': 'editMovie',
    '/login': 'login',
    '/register': 'register',
    '/logout': 'logout',
}
const views = {
    'home': renderHome,
    'addMovie': renderHome,
    'movie': renderHome,
    'editMovie': renderHome,
    'login': renderLogin,
    'register': renderRegister,
    'logout': logout,
}

const router = initialize(links, views);
router.route('/');
navigator.updateNav();
