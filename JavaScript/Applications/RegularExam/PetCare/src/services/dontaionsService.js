import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    donations: '/data/donation',
    petDonations: (petId) => `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    userDonation: (petId, userId) =>
        `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
};

export function readPetDonations(petId) {
    return httpClient.get(endpoints.petDonations(petId));
}

export function createPetDonations(petId) {
    return httpClient.post(endpoints.donations, petId);
}

export function readUserDonations(petId, userId) {
    return httpClient.get(endpoints.userDonation(petId, userId));
}
