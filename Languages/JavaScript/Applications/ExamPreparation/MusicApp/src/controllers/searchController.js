import { searchAlbums } from '../services/albumsService.js';
import { isLogged } from '../utils/auth.js';
import { resultsTemplate, searchTemplate } from '../views/searchView.js';

export function searchController(ctx, next) {
    ctx.render(searchTemplate(search));

    async function search() {
        let query = document.getElementById('search-input').value;

        if (query) {
            ctx.render(searchTemplate(search, renderResults(query)));
        } else {
            alert('Empty field!');
        }
    }

    async function renderResults(query) {
        let albums = await searchAlbums(query);

        return resultsTemplate(albums, isLogged());
    }
}
