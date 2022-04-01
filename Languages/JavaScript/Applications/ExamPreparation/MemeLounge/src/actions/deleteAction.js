import { deleteMeme } from "../services/memesService.js";

export async function deleteAction(ctx, event) {
    let choice = confirm('Are you sure you want to delete this meme?');

    if (choice) {
        await deleteMeme(ctx.params.id);
        ctx.page.redirect('/all-memes');
    }
}
