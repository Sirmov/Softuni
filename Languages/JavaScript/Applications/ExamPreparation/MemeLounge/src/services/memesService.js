import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    allMemes: '/data/memes?sortBy=_createdOn%20desc',
    memes: '/data/memes',
    meme: (memeId) => `/data/memes/${memeId}`,
    userMemes: (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
};

export function readAllMemes() {
    return httpClient.get(endpoints.allMemes);
}

export function createMeme(meme) {
    return httpClient.post(endpoints.memes, meme);
}

export function readMeme(memeId) {
    return httpClient.get(endpoints.meme(memeId));
}

export function deleteMeme(memeId) {
    return httpClient.del(endpoints.meme(memeId));
}

export function updateMeme(memeId, meme) {
    return httpClient.put(endpoints.meme(memeId), meme);
}

export function readUserMemes(userId) {
    return httpClient.get(endpoints.userMemes(userId));
}
