import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    addLike: '/data/likes',
    bookLikes: (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    userLike: (userId, bookId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export function createLike(bookId) {
    return httpClient.post(endpoints.addLike, { bookId });
}

export function readBookLikes(bookId) {
    return httpClient.get(endpoints.bookLikes(bookId));
}

export function readUserLike(userId, bookId) {
    return httpClient.get(endpoints.userLike(userId, bookId));
}
