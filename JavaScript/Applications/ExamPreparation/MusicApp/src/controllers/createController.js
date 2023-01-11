import { createAlbum } from '../services/albumsService.js';
import { createTemplate } from '../views/createView.js';

const allowedData = ['name', 'imgUrl', 'price', 'releaseDate', 'artist', 'genre', 'description'];

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

        if (Object.entries(data).some(([k, v]) => v === '')) {
            alert('Empty fields!');
        } else {
            await createAlbum(data);
            ctx.page.redirect('/catalog');
        }
    }
}
