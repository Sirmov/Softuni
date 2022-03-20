import { login } from '../api/request.js';
import { loginTemplate } from '../templates.js';

// Export render function
export function renderLogin(ctx, next) {
    ctx.setActive();
    ctx.render(loginTemplate(loginSubmit));

    async function loginSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();

        if (email && password) {
            await login(email, password);
            alert('Successful login!');
            event.target.reset();
            ctx.updateNav();
            ctx.page.redirect('/dashboard');
        } else {
            alert('Empty input!');
        }
    }
}
