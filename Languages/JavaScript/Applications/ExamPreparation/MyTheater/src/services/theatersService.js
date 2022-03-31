import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    allTheaters: '/data/theaters?sortBy=_createdOn%20desc&distinct=title',
    theaters: '/data/theaters',
    theater: (theaterId) => `/data/theaters/${theaterId}`,
    userTheaters: (userId) => `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
};

export function readAllTheaters() {
    return httpClient.get(endpoints.allTheaters);
}

export function createTheater(theater) {
    return httpClient.post(endpoints.theaters, theater);
}

export function readTheater(theaterId) {
    return httpClient.get(endpoints.theater(theaterId));
}

export function updateTheater(theaterId, theater) {
    return httpClient.put(endpoints.theater(theaterId), theater);
}

export function deleteTheater(theaterId) {
    return httpClient.del(endpoints.theater(theaterId));
}

export function readUserTheaters(userId) {
    return httpClient.get(endpoints.userTheaters(userId));
}
