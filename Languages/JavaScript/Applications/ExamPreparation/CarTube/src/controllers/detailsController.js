import { detailsTemplate, listingTemplate } from '../views/detailsView.js';

export function detailsController(ctx, next) {
    ctx.render(detailsTemplate(renderListing()));

    async function renderListing() {
        let listing = await ctx.services.getListing(ctx.params.id);
        let isOwner = ctx.auth.getUserId() === listing._ownerId;

        return listingTemplate(listing, isOwner);
    }
}
