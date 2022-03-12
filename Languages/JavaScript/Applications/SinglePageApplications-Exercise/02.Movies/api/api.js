// Backend api logic specific to the service
import * as auth from '../auth/authentication.js';

const host = 'http://localhost:3030';
const endpoints = {
    'login': '/users/login',
    'register': '/users/register',
    'logout': '/users/logout'
};

async function request(url, options) {
    try {
        const response = await fetch(host + url, options);

        if (!response.ok) {
            // Clear storage if token has expired
            if (response.status === 403) {
                auth.clearUserData();
            }
            let error = await response.json();
            throw new Error(error.message);
        }

        // Check if response body is empty
        if (response.status === 204) {
            return response;
        } else {
            return response.json();
        }
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

function createOptions(method = 'GET', data) {
    const options = {
        method,
        headers: {}
    }

    if (data !== undefined) {
        const serializedData = JSON.stringify(data);
        options.headers['Content-Type'] = 'application/json';
        options.body = serializedData;
    }

    const accessToken = auth.getAccessToken();

    if (accessToken !== undefined) {
        options.headers['X-Authorization'] = accessToken;
    }

    return options;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('POST', data));
}

export async function put(url, data) {
    return request(url, createOptions('PUT', data));
}

export async function del(url) {
    return request(url, createOptions('DELETE'));
}

export async function login(email, password) {
    const userData = await post(endpoints.login, { email, password });
    auth.saveUserData(userData);
}

export async function register(email, password) {
    const userData = await post(endpoints.register, { email, password });
    auth.saveUserData(userData);
}


export async function logout() {
    await get(endpoints.logout);
    auth.clearUserData();
}
