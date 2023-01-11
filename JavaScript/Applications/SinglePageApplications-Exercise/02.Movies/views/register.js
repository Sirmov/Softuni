import { register } from "../api/request.js";
import { updateNav } from "../navigation/navigator.js";
import { route, showView } from "../navigation/router.js";

const registerView = document.querySelector('div.register-view');
const formElement = registerView.querySelector('form');

formElement.addEventListener('submit', onRegister);

export function renderRegister() {
    showView(registerView);
}

async function onRegister(event) {
    event.preventDefault();

    let formData = new FormData(formElement);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeat = formData.get('repeatPassword');

    if (email && password.length >= 6 && repeat === password) {
        try {
            await register(email, password);
            alert('Successful registration!');
            updateNav();
            route('/');
        } catch (error) {
            formElement.reset();
        }
    } else {
        alert('Invalid input!');
        formElement.reset();
    }
}
