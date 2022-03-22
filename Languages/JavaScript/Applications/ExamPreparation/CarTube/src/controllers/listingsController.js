import { listingsTemplate, listingTemplate } from '../views/listingsView.js';

export function listingsController(ctx, next) {
    let isMyListings = ctx.page.current === '/my-listings';
    ctx.render(listingsTemplate(renderListings(isMyListings), isMyListings));


    async function renderListings(isMyListings) {
        let listings = [];

        if (isMyListings) {
            listings = await ctx.services.getMyListings(ctx.auth.getUserId());            
        } else {
            listings = await ctx.services.getListings();
        }
        
        return listingTemplate(listings, isMyListings);
    }
}
