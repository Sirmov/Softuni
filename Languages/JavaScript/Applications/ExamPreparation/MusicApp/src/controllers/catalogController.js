import { getAllAlbums } from '../services/albumsService.js';
import { albumsTemplate, catalogTemplate } from '../views/catalogView.js';

export function catalogController(ctx, next) {
    ctx.render(catalogTemplate(renderAlbums()));

    async function renderAlbums() {
        let albums = await getAllAlbums();

        return albumsTemplate(albums);
    }
}
