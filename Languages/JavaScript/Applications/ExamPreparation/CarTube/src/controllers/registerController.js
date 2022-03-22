import { registerTemplate } from '../views/registerView.js';

export function registerController(ctx, next) {
    ctx.render(registerTemplate(registerSubmit));

    async function registerSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        let username = formData.get('username').trim();
        let password = formData.get('password').trim();
        let repeatPass = formData.get('repeatPass').trim();

        if (username && password) {
            if (repeatPass === password) {
                await ctx.services.register(username, password);
                event.target.reset();
                ctx.page.redirect('/listings');
            } else {
                alert("Passwords dont't match");
            }
        } else {
            alert('Empty input!');
        }
    }
}
