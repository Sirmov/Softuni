import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

const url = 'http://localhost:3030/jsonstore/collections/books';
const loadAllBooksBtn = document.getElementById('loadBooks');
const tableContainer = document.querySelector('div.table');
const addForm = document.getElementById('add-form');
const editForm = document.getElementById('edit-form');
editForm.style.display = 'none';
let currentBookId;

// Attaching event listeners
addForm.addEventListener('submit', addSubmit);
editForm.addEventListener('submit', editSubmit);
loadAllBooksBtn.addEventListener('click', renderTable);

// Templates
const bookRowTemplate = (book) =>
    html`<tr>
        <td>${book[1].title}</td>
        <td>${book[1].author}</td>
        <td data-id=${book[0]}>
            <button @click=${editBook}>Edit</button>
            <button @click=${deleteBook}>Delete</button>
        </td>
    </tr>`;

const tableTemplate = (books) =>
    html`<table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            ${repeat(
                books,
                (book) => book[0],
                (book, index) => bookRowTemplate(book)
            )}
        </tbody>
    </table>`;

// Event handlers
async function editBook(event) {
    let bookId = event.currentTarget.parentElement.dataset.id;
    let book = await getBook(bookId);
    currentBookId = bookId;

    let titleInput = editForm.querySelector('input[name="title"]');
    let authorInput = editForm.querySelector('input[name="author"]');
    titleInput.value = book.title;
    authorInput.value = book.author;

    addForm.style.display = 'none';
    editForm.style.display = 'block';
}

async function deleteBook(event) {
    try {
        let bookId = event.currentTarget.parentElement.dataset.id;
        let bookRow = event.currentTarget.parentElement.parentElement;
        let response = await fetch(`${url}/${bookId}`, { method: 'DELETE' });

        if (!response.ok) {
            let body = await response.json();
            throw new Error(body.message);
        }

        alert('Successfully delete!');
        bookRow.remove();
    } catch (error) {
        alert(error.message);
    }
}

async function editSubmit(event) {
    event.preventDefault();

    let formData = new FormData(editForm);
    let title = formData.get('title');
    let author = formData.get('author');

    if (title && author) {
        try {
            await putBook(currentBookId, { title, author });
            editForm.reset();
            alert('Successfully edited!');
            addForm.style.display = 'block';
            editForm.style.display = 'none';
            await renderTable();
        } catch (error) {
            editForm.reset();
        }
    } else {
        alert('Empty input!');
    }
}

async function addSubmit(event) {
    event.preventDefault();

    let formData = new FormData(addForm);
    let title = formData.get('title');
    let author = formData.get('author');

    if (title && author) {
        try {
            await postBook({ title, author });
            addForm.reset();
            alert('Successfully created!');
            await renderTable();
        } catch (error) {
            addForm.reset();
        }
    } else {
        alert('Empty input!');
    }
}

async function renderTable() {
    let books = await getAllBooks();
    books = Object.entries(books);
    render(tableTemplate(books), tableContainer);
}

// Request logic

async function putBook(bookId, book) {
    try {
        let response = await fetch(`${url}/${bookId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(book)
        });

        if (!response.ok) {
            let body = response.json();
            throw new Error(body.message);
        }
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

async function postBook(book) {
    try {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(book)
        });

        if (!response.ok) {
            let body = response.json();
            throw new Error(body.message);
        }
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

async function getAllBooks() {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            let body = await response.json();
            throw new Error(body.message);
        }

        return response.json();
    } catch (error) {
        alert(error.message);
    }
}

async function getBook(id) {
    try {
        let response = await fetch(`${url}/${id}`);

        if (!response.ok) {
            let body = await response.json();
            throw new Error(body.message);
        }

        return response.json();
    } catch (error) {
        alert(error.message);
    }
}
