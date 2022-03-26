import { registerEmail } from '../services/usersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { registerTemplate } from '../views/registerView.js';

const allowedData = ['email', 'password', 'confirm-pass'];

export function registerController(ctx, next) {
    ctx.render(registerTemplate(createSubmitHandler(ctx, registerSubmit, allowedData)));
}

async function registerSubmit(ctx, data, event) {
    console.log(data);
    if (data['confirm-pass'] === data.password) {
        await registerEmail(data.email, data.password);
        event.target.reset();
        ctx.page.redirect('/');
    } else {
        alert("Passwords don't match!");
    }
}
