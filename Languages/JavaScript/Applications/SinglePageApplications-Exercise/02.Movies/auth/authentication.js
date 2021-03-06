// Module handling user authentication

const storage = localStorage;
const userDataKey = 'user';


export function getUserData() {
    const serializedUserData = storage.getItem(userDataKey);

    if (serializedUserData !== null) {
        const userData = JSON.parse(serializedUserData);
        return userData;
    }
}

export function getAccessToken() {
    const userData = getUserData();

    if (userData !== undefined) {
        return userData.accessToken;
    }
}

export function getUserId() {
    const userData = getUserData();

    if (userData !== undefined) {
        return userData._id;
    }
}

export function saveUserData(userData) {
    storage.setItem(userDataKey, JSON.stringify(userData));
}

export function clearUserData() {
    storage.removeItem(userDataKey);
}
