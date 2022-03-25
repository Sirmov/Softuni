import { createGame } from '../services/gamesService.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['title', 'category', 'maxLevel', 'imageUrl', 'summary'];

export function createController(ctx, next) {
    ctx.render(createTemplate(createSubmit));

    async function createSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const formEntries = [...formData.entries()];
        const data = formEntries.reduce(
            (a, [k, v]) => (allowedData.includes(k) ? Object.assign(a, { [k]: v }) : a),
            {}
        );

        if (Object.values(data).some((x) => x === '')) {
            alert('Empty fields!');
        } else {
            await createGame(data);
            event.target.reset();
            ctx.page.redirect('/');
        }
    }
}
