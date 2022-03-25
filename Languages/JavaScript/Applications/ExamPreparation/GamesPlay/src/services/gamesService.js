import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    getAllGames: '/data/games?sortBy=_createdOn%20desc',
    getLatestGames: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    games: '/data/games',
    game: (gameId) => `/data/games/${gameId}`
};

export function getAllGames() {
    return httpClient.get(endpoints.getAllGames);
}

export function getRecentGames() {
    return httpClient.get(endpoints.getLatestGames);
}

export function createGame(game) {
    return httpClient.post(endpoints.games, game);
}

export function getGame(gameId) {
    return httpClient.get(endpoints.game(gameId));
}

export function updateGame(gameId, game) {
    return httpClient.put(endpoints.game(gameId), game);
}

export function deleteGame(gameId) {
    return httpClient.del(endpoints.game(gameId));
}
