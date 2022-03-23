import { getAlbum } from '../services/albumsService.js';
import { getUserId } from '../utils/auth.js';
import { albumTemplate, detailsTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderAlbum()));

    async function renderAlbum() {
        let album = await getAlbum(ctx.params.id);
        let isOwner = getUserId() === album._ownerId;

        return albumTemplate(album, isOwner);
    }
}
