import * as httpClient from '../utils/httpClient.js';
import * as auth from '../utils/auth.js';

const endpoints = {
    albums: '/data/albums',
    getAllAlbums: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    album: (albumId) => `/data/albums/${albumId}`
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
