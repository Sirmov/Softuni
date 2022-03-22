import { byYearTemplate, listingsTemplate } from '../views/byYearView.js';

export function byYearController(ctx, next) {
    ctx.render(byYearTemplate(search));

    async function search() {
        let searchYear = document.getElementById('search-input').value.trim();
        let listings = await ctx.services.getListingsByYear(searchYear);

        ctx.render(byYearTemplate(search, listingsTemplate(listings)));
    }
}
