import { loginTemplate } from '../views/loginView.js';

export function loginController(ctx, next) {
    ctx.render(loginTemplate(loginSubmit));

    async function loginSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let username = formData.get('username').trim();
        let password = formData.get('password').trim();

        if (username && password) {
            await ctx.services.login(username, password);
            event.target.reset();
            ctx.page.redirect('/listings');
        } else {
            alert('Empty input!');
        }
    }
}
