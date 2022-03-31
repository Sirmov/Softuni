import { registerEmail } from '../services/usersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { registerTemplate } from '../views/registerView.js';

const allowedData = ['email', 'password', 'conf-pass'];

export function registerController(ctx, next) {
    ctx.render(registerTemplate(createSubmitHandler(ctx, registerSubmit, allowedData)));
}

async function registerSubmit(ctx, data, event) {
    if (data.confPass === data.password) {
        await registerEmail(data.email, data.password);
        event.target.reset();
        ctx.page.redirect('/');
    } else {
        throw {
            isOperational: true,
            error: new Error("Passwords don't match!"),
            message: error.message
        };
    }
}
