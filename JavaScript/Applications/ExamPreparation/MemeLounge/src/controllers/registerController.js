import { register } from '../services/usersService.js';
import { createSubmitHandler, notification } from '../utils/handler.js';
import { registerTemplate } from '../views/registerView.js';

const allowedData = ['username', 'email', 'password', 'repeatPass', 'gender'];

export function registerController(ctx, next) {
    ctx.render(registerTemplate(createSubmitHandler(ctx, registerSubmit, allowedData)));
}

async function registerSubmit(ctx, data, event) {
    console.log(data);

    if (data.repeatPass === data.password) {
        await register({ username: data.username, email: data.email, password: data.password, gender: data.gender });
        event.target.reset();
        ctx.page.redirect('/all-memes');
    } else {
        notification("Passwords don't match!");
        throw new Error("Passwords don't match!");
    }
}
