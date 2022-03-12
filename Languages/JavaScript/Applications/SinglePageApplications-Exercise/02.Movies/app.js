// Application entry point

import { initialize } from "./navigation/router.js";
import * as navigator from "./navigation/navigator.js";
import { renderHome } from "./views/home.js";
import { renderLogin } from "./views/login.js";
import { renderRegister } from "./views/register.js";
import { logout } from "./api/request.js";
import { renderAddMovie } from "./views/addMovie.js";
import { renderMovie } from "./views/movie.js";

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
    'addMovie': renderAddMovie,
    'movie': renderMovie,
    'editMovie': '',
    'login': renderLogin,
    'register': renderRegister,
    'logout': renderLogout,
}

navigator.updateNav();
const router = initialize(links, views);
router.route('/');

async function renderLogout() {
    await logout();
    alert('Successful logout!');
    navigator.updateNav();
    router.route('/login');
}
