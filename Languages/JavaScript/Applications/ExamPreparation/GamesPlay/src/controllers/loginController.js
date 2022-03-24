import { login } from '../services/usersService.js';
import { loginTemplate } from '../views/loginView.js';

export function loginController(ctx, next) {
    ctx.render(loginTemplate(loginSubmit));

    async function loginSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let email = formData.get('email');
        let password = formData.get('password');

        if (email && password) {
            await login(email, password);
            event.target.reset();
            ctx.page.redirect('/');
        } else {
            alert('Empty fields!');
        }
    }
}
