import { deletePet } from '../services/petsService.js';

export async function deleteAction(ctx, event) {
    const choice = confirm('Are you sure you want to delete this article?');

    if (choice) {
        await deletePet(ctx.params.id);
        ctx.page.redirect('/');
    }
}
