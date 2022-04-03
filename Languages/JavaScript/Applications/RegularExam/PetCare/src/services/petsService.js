import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    allPets: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    pets: '/data/pets',
    pet: (petId) => `/data/pets/${petId}`
};

export function readAllPets() {
    return httpClient.get(endpoints.allPets);
}

export function createPet(pet) {
    return httpClient.post(endpoints.pets, pet);
}

export function readPet(petId) {
    return httpClient.get(endpoints.pet(petId));
}

export function updatePet(petId, pet) {
    return httpClient.put(endpoints.pet(petId), pet);
}

export function deletePet(petId) {
    return httpClient.del(endpoints.pet(petId));
}
