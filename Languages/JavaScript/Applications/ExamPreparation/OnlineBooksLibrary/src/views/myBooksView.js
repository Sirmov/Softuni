import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const myBooksTemplate = (booksPromise) =>
    html`<section id="my-books-page" class="my-books">
        <h1>My Books</h1>
        ${until(booksPromise, spinner)}
    </section>`;

export const booksTemplate = (books) =>
    html`${books.length > 0
        ? html`<!-- Display ul: with list-items for every user's books (if any) -->
              <ul class="my-books-list">
                  ${repeat(
                      books,
                      (book) => book._id,
                      (book, index) => bookTemplate(book)
                  )}
              </ul>`
        : html`<!-- Display paragraph: If the user doesn't have his own books  -->
              <p class="no-books">No books in database!</p>`}`;

const bookTemplate = (book) =>
    html`<li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl} /></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>`;
