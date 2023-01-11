import { delAlbum } from '../services/albumsService.js';

export async function deleteController(ctx, next) {
    let choice = confirm('Are you sure you want to delete this album?');

    if (choice) {
        await delAlbum(ctx.params.id);
        ctx.page.redirect('/catalog');
    }
}
