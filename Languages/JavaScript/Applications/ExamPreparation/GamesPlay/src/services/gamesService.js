import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    getAllGames: '/data/games?sortBy=_createdOn%20desc',
};

export function getAllGames() {
    return httpClient.get(endpoints.getAllGames);
}
