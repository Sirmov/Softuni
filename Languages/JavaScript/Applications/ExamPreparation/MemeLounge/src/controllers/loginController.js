import { loginEmail } from '../services/usersService.js';
import { createSubmitHandler } from '../utils/handler.js';
import { loginTemplate } from '../views/loginView.js';

const allowedData = ['email', 'password'];

export function loginController(ctx, next) {
    ctx.render(loginTemplate(createSubmitHandler(ctx, loginSubmit, allowedData)));
}

async function loginSubmit(ctx, data, event) {
    await loginEmail(data.email, data.password);
    event.target.reset();
    ctx.page.redirect('/all-memes');
}
