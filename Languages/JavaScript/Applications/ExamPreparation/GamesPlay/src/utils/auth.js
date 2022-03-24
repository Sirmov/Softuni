// Module handling user authorization

// Storage and user data key
const storage = localStorage;
const userDataKey = 'user';

// Get user data
export function getUserData() {
    const serializedUserData = storage.getItem(userDataKey);

    if (serializedUserData !== null) {
        const userData = JSON.parse(serializedUserData);
        return userData;
    }
}

// Get access token
export function getAccessToken() {
    const userData = getUserData();

    if (userData !== undefined) {
        return userData.accessToken;
    }
}

// Get user id
export function getUserId() {
    const userData = getUserData();

    if (userData !== undefined) {
        return userData._id;
    }
}

// Get user username
export function getUserUsername() {
    const userData = getUserData();

    if (userData !== undefined) {
        return userData.username;
    }
}

// Is logged in
export function isLogged() {
    const userData = getUserData();

    return Boolean(userData);
}

// Save user data
export function saveUserData(userData) {
    storage.setItem(userDataKey, JSON.stringify(userData));
}

// Clear user data
export function clearUserData() {
    storage.removeItem(userDataKey);
}
