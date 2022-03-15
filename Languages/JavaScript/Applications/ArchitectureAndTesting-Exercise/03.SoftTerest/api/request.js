// Request logic specific to the application business logic
import * as api from './api.js';

const endpoints = {
    ideas: '/data/ideas',
    getIdeas: '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc'
};

export async function logout() {
    return api.logout();
}

export async function login(email, password) {
    return api.login(email, password);
}

export async function register(email, password) {
    return api.register(email, password);
}

export async function getIdeas() {
    return api.get(endpoints.getIdeas);
}

export async function postIdea(idea) {
    return api.post(endpoints.ideas, idea);
}

export async function getIdea(ideaId) {
    return api.get(`${endpoints.ideas}/${ideaId}`);
}

export async function deleteIdea(ideaId) {
    return api.del(`${endpoints.ideas}/${ideaId}`);
}
