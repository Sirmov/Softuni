// Request logic specific to the application business logic
import * as api from './api.js';

const endpoints = {
    ideas: '/data/ideas',
    getIdeas: '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc'
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

export function getIdeas() {
    return api.get(endpoints.getIdeas);
}

export function postIdea(idea) {
    return api.post(endpoints.ideas, idea);
}

export function getIdea(ideaId) {
    return api.get(`${endpoints.ideas}/${ideaId}`);
}

export function deleteIdea(ideaId) {
    return api.del(`${endpoints.ideas}/${ideaId}`);
}
