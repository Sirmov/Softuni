import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    albums: '/data/albums',
    getAllAlbums: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    album: (albumId) => `/data/albums/${albumId}`,
    search: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`
};

export function getAllAlbums() {
    return httpClient.get(endpoints.getAllAlbums);
}

export function createAlbum(album) {
    return httpClient.post(endpoints.albums, album);
}

export function getAlbum(albumId) {
    return httpClient.get(endpoints.album(albumId));
}

export function updateAlbum(albumId, album) {
    return httpClient.put(endpoints.album(albumId), album);
}

export function delAlbum(albumId) {
    return httpClient.del(endpoints.album(albumId));
}

export function searchAlbums(query) {
    return httpClient.get(endpoints.search(query));
}
