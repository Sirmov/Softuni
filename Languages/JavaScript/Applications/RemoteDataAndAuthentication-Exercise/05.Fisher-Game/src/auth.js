import { route } from "./router.js";
import { loadCatches } from "./pages/home.js";

const guestNavigation = document.querySelector('header nav div#guest');
const userNavigation = document.querySelector('header nav div#user');
const welcomeParagraph = document.querySelector('header nav p.email');
const addBtn = document.querySelector('section#home-view aside form#addForm button.add');

export function authenticate() {
    let jsonUser = localStorage.getItem('user');
    updateNavigation(jsonUser);
    jsonUser ? addBtn.disabled = false : addBtn.disabled = true;
    loadCatches();
}

export async function logout() {
    const logoutURL = 'http://localhost:3030/users/logout';

    try {
        let response = await fetch(logoutURL, {
            method: 'GET',
            headers: {
                'X-Authorization': getAccessToken()
            }
        });

        if (!response.ok) {
            throw new Error();
        }
    } catch (error) {
        alert('Error logging out!');
    }

    localStorage.removeItem('user');
    authenticate();
    route('/');
}

export function getAccessToken() {
    let jsonUser = localStorage.getItem('user');

    if (jsonUser) {
        return JSON.parse(localStorage.getItem('user')).accessToken;
    }
}

export function getUserId() {
    let jsonUser = localStorage.getItem('user');

    if (jsonUser) {
        return JSON.parse(localStorage.getItem('user'))._id;
    }
}

function updateNavigation(jsonUser) {
    if (jsonUser) {
        let user = JSON.parse(localStorage.getItem('user'));

        guestNavigation.style.display = 'none';
        userNavigation.style.display = 'inline-block';
        welcomeParagraph.innerHTML = `Welcome, <span>${user.email}</span>`;
    } else {
        guestNavigation.style.display = 'inline-block';
        userNavigation.style.display = 'none';
        welcomeParagraph.innerHTML = 'Welcome, <span>guest</span>';
    }
}
