import { authenticate } from "../auth.js";

const registerView = document.getElementById('register-view');
const form = registerView.querySelector('form');
const registerURL = 'http://localhost:3030/users/register';

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeat = formData.get('rePass');

    if (email && password && repeat && password === repeat) {
        try {
            let response = await fetch(registerURL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, password })
            });

            if (!response.ok) {
                throw new Error();
            }
        } catch (error) {
            alert('Error registering!');
        }

        let body = await response.json();
        localStorage.setItem('user', JSON.stringify(body));
        authenticate();
        alert('Successfully registered!');
    } else {
        alert('Invalid input!');
    }
});

export function renderRegister() {
    registerView.style.display = 'inline-block';
}
