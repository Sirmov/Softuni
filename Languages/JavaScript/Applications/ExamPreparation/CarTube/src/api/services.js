// Request logic specific to the application business logic
import * as api from './api.js';

const endpoints = {
    getListings: '/data/cars?sortBy=_createdOn%20desc',
    listing: (listingId) => `/data/cars/${listingId}`,
    postListing: '/data/cars',
    myListings: (userId) => `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    getByYear: (year) => `/data/cars?where=year%3D${year}`
};

export function login(username, password) {
    return api.login(username, password);
}

export function register(username, password) {
    return api.register(username, password);
}

export function logout() {
    return api.logout();
}

export function getListings() {
    return api.get(endpoints.getListings);
}

export function getListing(listingId) {
    return api.get(endpoints.listing(listingId));
}

export function postListing(listing) {
    return api.post(endpoints.postListing, listing);
}

export function putListing(listingId, listing) {
    return api.put(endpoints.listing(listingId), listing);
}

export function delListing(listingId) {
    return api.del(endpoints.listing(listingId));
}

export function getMyListings(userId) {
    return api.get(endpoints.myListings(userId));
}

export function getListingsByYear(year) {
    return api.get(endpoints.getByYear(year));
}
