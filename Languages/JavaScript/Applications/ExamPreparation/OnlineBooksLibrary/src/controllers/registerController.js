import { register } from '../services/usersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { registerTemplate } from '../views/registerView.js';

const allowedData = ['email', 'password', 'conf-pass'];

export function registerController(ctx, next) {
    ctx.render(registerTemplate(createSubmitHandler(ctx, registerSubmit, allowedData)));
}

async function registerSubmit(ctx, data, event) {
    if (data.confPass === data.password) {
        await register(email, password);
        event.target.reset();
        ctx.page.redirect('/');
    } else {
        alert("Passwords don't match!");
    }
}
