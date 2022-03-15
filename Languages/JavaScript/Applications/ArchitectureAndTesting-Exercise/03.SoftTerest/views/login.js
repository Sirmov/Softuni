import { login } from '../api/request.js';
import { updateNav } from '../navigation/navigator.js';
import { route, showView } from '../navigation/router.js';

// Select view
const loginView = document.querySelector('div.login-view');
const signUpLink = loginView.querySelector('a[href="/register"]');
const form = loginView.querySelector('form');
signUpLink.addEventListener('click', signUp);
form.addEventListener('submit', loginSubmit);

// Export render function
export async function renderLogin() {
    showView(loginView);
}

async function signUp(event) {
    event.preventDefault();
    const url = new URL(event.currentTarget.href);
    await route(url.pathname);
}

async function loginSubmit(event) {
    event.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email');
    let password = formData.get('password');

    if (email && password) {
        try {
            await login(email, password);
            alert('Successfully logged in!');
            form.reset();
            updateNav();
            await route('/');
        } catch (error) {
            form.reset();
        }
    } else {
        alert('Empty input!');
    }
}
