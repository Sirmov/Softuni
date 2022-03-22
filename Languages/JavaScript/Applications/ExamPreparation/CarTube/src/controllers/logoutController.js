export async function logoutController(ctx, next) {
    await ctx.services.logout();
    ctx.page.redirect('/');
}
