import { register } from '../api/request.js';
import { registerTemplate } from '../templates.js';

// Export render function
export function renderRegister(ctx, next) {
    ctx.setActive();
    ctx.render(registerTemplate(registerSubmit));

    async function registerSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let rePass = formData.get('rePass').trim();

        if (email && password && rePass) {
            if (rePass === password) {
                await register(email, password);
                alert('Successful register!');
                event.target.reset();
                ctx.updateNav();
                ctx.page.redirect('/dashboard');
            } else {
                alert("Passwords don't match!");
            }
        } else {
            alert('Empty input!');
        }
    }
}
