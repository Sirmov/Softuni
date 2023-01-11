import { authenticate } from "../auth.js";

const loginView = document.getElementById('login-view');
const form = loginView.querySelector('form');
const url = 'http://localhost:3030/users/login';

form.addEventListener('submit', async (e) => {
    e.preventDefault();
    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');

    if (email && password) {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        let body = await response.json();

        if (!response.ok) {
            alert(body.message);
            return;
        }

        localStorage.setItem('user', JSON.stringify(body));
        authenticate();
        alert('Successful login!');
    } else {
        alert('Invalid input!');
    }
});

export function renderLogin() {
    loginView.style.display = 'inline-block';
}
