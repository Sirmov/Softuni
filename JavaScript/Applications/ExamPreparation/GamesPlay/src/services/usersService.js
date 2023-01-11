import * as httpClient from '../utils/httpClient.js';
import * as auth from '../utils/auth.js';

const endpoints = {
    login: '/users/login',
    register: '/users/register',
    logout: '/users/logout'
};

export async function login(email, password) {
    const userData = await httpClient.post(endpoints.login, { email, password });
    auth.saveUserData(userData);
}

export async function register(email, password) {
    const userData = await httpClient.post(endpoints.register, { email, password });
    auth.saveUserData(userData);
}

export async function loginUsername(username, password) {
    const userData = await httpClient.post(endpoints.login, { username, password });
    auth.saveUserData(userData);
}

export async function registerUsername(username, password) {
    const userData = await httpClient.post(endpoints.register, { username, password });
    auth.saveUserData(userData);
}

export async function logout() {
    httpClient.get(endpoints.logout);
    auth.clearUserData();
}
