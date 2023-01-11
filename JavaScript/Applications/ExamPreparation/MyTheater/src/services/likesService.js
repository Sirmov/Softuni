import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    likes: '/data/likes',
    theaterLikes: (theaterId) => `/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`,
    userLike: (userId, theaterId) => `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`
};

export function createLike(theaterId) {
    return httpClient.post(endpoints.likes, { theaterId });
}

export function readTheaterLikes(theaterId) {
    return httpClient.get(endpoints.theaterLikes(theaterId));
}

export function readUserLike(userId, theaterId) {
    return httpClient.get(endpoints.userLike(userId, theaterId));
}
