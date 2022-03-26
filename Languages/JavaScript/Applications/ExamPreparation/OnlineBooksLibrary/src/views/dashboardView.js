import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const dashboardTemplate = (booksPromise) =>
    html`<section id="dashboard-page" class="dashboard">
        <h1>Dashboard</h1>
        ${until(booksPromise, spinner)}
    </section>`;

export const booksTemplate = (books) =>
    html`${books.length > 0
        ? html`<!-- Display ul: with list-items for All books (If any) -->
              <ul class="other-books-list">
                  ${repeat(
                      books,
                      (book) => book._id,
                      (book, index) => bookTemplate(book)
                  )}
              </ul>`
        : html`<!-- Display paragraph: If there are no books in the database -->
              <p class="no-books">No books in database!</p>`}`;

const bookTemplate = (book) =>
    html`<li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl} /></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>`;
