import { getGame, updateGame } from '../services/gamesService.js';
import { editTemplate } from '../views/editView.js';

const allowedData = ['title', 'category', 'maxLevel', 'imageUrl', 'summary'];

export async function editController(ctx, next) {
    let game = await getGame(ctx.params.id);

    ctx.render(editTemplate(editSubmit, game));

    async function editSubmit(event) {
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
            await updateGame(ctx.params.id, data);
            ctx.page.redirect(`/details/${ctx.params.id}`);
        }
    }
}
