import { registerEmail } from '../services/usersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { registerTemplate } from '../views/registerView.js';

const allowedData = ['email', 'password', 'repeatPassword'];

export function registerController(ctx, next) {
    ctx.render(registerTemplate(createSubmitHandler(ctx, registerSubmit, allowedData)));
}

async function registerSubmit(ctx, data, event) {
    if (data.repeatPassword === data.password) {
        await registerEmail(data.email, data.password);
        event.target.reset();
        ctx.page.redirect('/');
    } else {
        alert("Passwords don't match!");
        throw new Error("Passwords don't match!");
    }
}
