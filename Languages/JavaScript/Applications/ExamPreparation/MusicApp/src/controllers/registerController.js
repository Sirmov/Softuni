import { register } from '../services/usersService.js';
import { registerTemplate } from '../views/registerView.js';

export function registerController(ctx, next) {
    ctx.render(registerTemplate(registerSubmit));

    async function registerSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let email = formData.get('email');
        let password = formData.get('password');
        let confPass = formData.get('conf-pass');

        if (email && password) {
            if (confPass === password) {
                await register(email, password);
                event.target.reset();
                ctx.page.redirect('/');
            } else {
                alert("Passwords don't match!");
            }
        } else {
            alert('Empty fields!');
        }
    }
}
