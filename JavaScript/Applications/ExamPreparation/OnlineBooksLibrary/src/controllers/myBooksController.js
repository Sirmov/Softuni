import { readMyBooks } from '../services/booksService.js';
import { getUserId } from '../utils/auth.js';
import { booksTemplate, myBooksTemplate } from '../views/myBooksView.js';

export function myBooksController(ctx, next) {
    ctx.render(myBooksTemplate(renderBooks()));
}

async function renderBooks() {
    let books = await readMyBooks(getUserId());

    return booksTemplate(books);
}
