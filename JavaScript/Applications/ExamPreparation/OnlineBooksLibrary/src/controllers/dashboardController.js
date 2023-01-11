import { readAllBooks } from '../services/booksService.js';
import { booksTemplate, dashboardTemplate } from '../views/dashboardView.js';

export function dashboardController(ctx, next) {
    ctx.render(dashboardTemplate(renderBooks()));
}

async function renderBooks() {
    let books = await readAllBooks();

    return booksTemplate(books);
}
