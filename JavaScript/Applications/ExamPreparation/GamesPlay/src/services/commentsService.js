import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    comment: '/data/comments',
    comments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`
};

export function readComments(gameId) {
    return httpClient.get(endpoints.comments(gameId));
}

export function createComment(comment, gameId) {
    return httpClient.post(endpoints.comment, { comment, gameId });
}
