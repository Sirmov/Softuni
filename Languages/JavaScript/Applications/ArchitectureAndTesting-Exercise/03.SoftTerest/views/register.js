import { register } from '../api/request.js';
import { updateNav } from '../navigation/navigator.js';
import { route, showView } from '../navigation/router.js';

const registerView = document.querySelector('div.register-view');
const signInLink = registerView.querySelector('a[href="/login"]');
const form = registerView.querySelector('form');
const digitRegex = /[\d]/g;
const symbolRegex = /[!@#$%^&*]/g;
signInLink.addEventListener('click', signIn);
form.addEventListener('submit', registerSubmit);

export async function renderRegister() {
    showView(registerView);
}

async function signIn(event) {
    event.preventDefault();
    const url = new URL(event.currentTarget.href);
    await route(url.pathname);
}

async function registerSubmit(event) {
    event.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeat = formData.get('repeatPassword');
    let errorMessages = [];

    if (email.length < 3) {
        errorMessages.push('The email should be at least 3 characters long');
    }
    if (!digitRegex.test(email) || !symbolRegex.test(email)) {
        errorMessages.push('The email should have digits and special characters');
    }
    if (password.length < 3) {
        errorMessages.push('The password should be at least 3 characters long.');
    }
    if (repeat !== password) {
        errorMessages.push('Repeat password does not match password');
    }

    if (errorMessages.length === 0) {
        try {
            await register(email, password);
            alert('Successfully registered!');
            form.reset();
            updateNav();
            await route('/');
        } catch (error) {
            form.reset();
        }
    } else {
        alert(errorMessages.join(' '));
        form.reset();
    }
}
