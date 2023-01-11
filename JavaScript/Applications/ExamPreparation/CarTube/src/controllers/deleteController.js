export async function deleteController(ctx, next) {
    let choice = confirm('Are you sure you want to delete this listing?');

    if (choice) {
        await ctx.services.delListing(ctx.params.id);
        ctx.page.redirect('/listings');
    }
}
