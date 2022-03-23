import { getAlbum, updateAlbum } from '../services/albumsService.js';
import { editTemplate } from '../views/editView.js';

const allowedData = ['name', 'imgUrl', 'price', 'releaseDate', 'artist', 'genre', 'description'];

export async function editController(ctx, next) {
    let album = await getAlbum(ctx.params.id);
    ctx.render(editTemplate(editSubmit, album));

    async function editSubmit(event) {
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
            await updateAlbum(ctx.params.id, data);
            ctx.page.redirect(`/details/${ctx.params.id}`);
        }
    }
}
