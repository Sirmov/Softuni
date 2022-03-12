// Request logic specific to the application business logic
import { updateNav } from '../navigation/navigator.js';
import { route } from '../navigation/router.js';
import * as api from './api.js'

const endpoints = {
    'movies': '/data/movies'
};

export async function logout() {
    await api.logout();
}

export async function register(email, password) {
    await api.register(email, password);
}

export async function login(email, password) {
    await api.login(email, password);
}

export async function getAllMovies() {
    let movies = await api.get(endpoints.movies);
    return movies;
}

export async function postMovie(movie) {
    await api.post(endpoints.movies, movie);
}

export async function getMovie(movieId) {
    return api.get(`${endpoints.movies}/${movieId}`);
}

export async function getMovieLikes(movieId) {
    return api.get(`/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
}
