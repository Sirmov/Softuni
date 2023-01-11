// Request logic specific to the application business logic
import * as api from './api.js';

const endpoints = {
    allFurniture: '/data/catalog',
    specificFurniture: (furnitureId) => `/data/catalog/${furnitureId}`,
    myFurniture: (userId) => `/data/catalog?where=_ownerId%3D%22${userId}%22`
};

export function logout() {
    return api.logout();
}

export function login(email, password) {
    return api.login(email, password);
}

export function register(email, password) {
    return api.register(email, password);
}

export function getAllFurniture() {
    return api.get(endpoints.allFurniture);
}

export function getFurnitureDetails(furnitureId) {
    return api.get(endpoints.specificFurniture(furnitureId));
}

export function getMyFurniture(userId) {
    return api.get(endpoints.myFurniture(userId));
}

export function postFurniture(furniture) {
    return api.post(endpoints.allFurniture, furniture);
}

export function updateFurniture(furnitureId, furniture) {
    return api.put(endpoints.specificFurniture(furnitureId), furniture);
}

export function delFurniture(furnitureId) {
    return api.del(endpoints.specificFurniture(furnitureId));
}
