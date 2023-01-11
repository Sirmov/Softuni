import { deleteTheater } from '../services/theatersService.js';

export async function deleteAction(ctx, event) {
    let choice = confirm('Are you sure you want to delete this event?');

    if (choice) {
        await deleteTheater(ctx.params.id);
        ctx.page.redirect('/profile');
    }
}
