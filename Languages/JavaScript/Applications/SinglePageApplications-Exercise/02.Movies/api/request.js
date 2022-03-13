// Request logic specific to the application business logic
import { updateNav } from '../navigation/navigator.js';
import { route } from '../navigation/router.js';
import * as api from './api.js'

const endpoints = {
    'movies': '/data/movies',
    'likes': '/data/likes'
};

export async function logout() {
    return await api.logout();
}

export async function register(email, password) {
    return await api.register(email, password);
}

export async function login(email, password) {
    return await api.login(email, password);
}

export async function getAllMovies() {
    let movies = await api.get(endpoints.movies);
    return movies;
}

export async function postMovie(movie) {
    return await api.post(endpoints.movies, movie);
}

export async function getMovie(movieId) {
    return api.get(`${endpoints.movies}/${movieId}`);
}

export async function getMovieLikes(movieId) {
    return api.get(`/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
}

export async function putMovie(movieId, movie) {
    return await api.put(`${endpoints.movies}/${movieId}`, movie);
}

export async function delMovie(movieId) {
    return await api.del(`${endpoints.movies}/${movieId}`);
}

export async function postLike(movieId) {
    return await api.post(`${endpoints.likes}`, { movieId })
}

export async function getUserLike(movieId, userId) {
    return api.get(`/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
}
