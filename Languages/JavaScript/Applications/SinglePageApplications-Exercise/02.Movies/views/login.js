import { login } from "../api/request.js";
import { route, showView } from "../navigation/router.js";
import { updateNav } from "../navigation/navigator.js";

const loginView = document.querySelector('div.login-view');
const formElement = loginView.querySelector('form');
formElement.addEventListener('submit', onLogin);

export function renderLogin() {
    showView(loginView);
}

async function onLogin(event) {
    event.preventDefault();

    let formData = new FormData(formElement);
    let email = formData.get('email');
    let password = formData.get('password');

    if (email && password.length >= 6) {
        try {
            await login(email, password);
            alert('Successful login!');
            updateNav();
            route('/');
            formElement.reset();
        } catch (error) {
            formElement.reset();
        }
    } else {
        alert('Invalid input!');
        formElement.reset();
    }
}
