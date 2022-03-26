import { deleteBook } from "../services/booksService.js";

export async function deleteBookAction(ctx, next) {
    let choice = confirm('Are you sure you want to delete this book?');
    if (choice) {
        await deleteBook(ctx.params.id);
        ctx.page.redirect('/');
    }
}
