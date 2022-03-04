const url = 'http://localhost:3030/jsonstore/collections/books';
const loadBooksBtn = document.getElementById('loadBooks');
const submitBtn = document.querySelector('form button');
let currentEditBookId;

submitBtn.addEventListener('click', async (e) => {
    e.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let title = formData.get('title');
    let author = formData.get('author');

    if (title && author) {
        if (e.currentTarget.textContent === 'Save') {
            try {
                let response = await fetch(`${url}/${currentEditBookId}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ author, title })
                })

                if (!response.ok) {
                    throw new Error();
                }

                loadBooksBtn.click();
                form.querySelector('h3').textContent = 'FORM';
                form.querySelector('button').textContent = 'Submit';
            } catch (error) {
                console.log('Error editing!');
            }
        } else if (e.currentTarget.textContent === 'Submit') {
            try {
                let response = await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ author, title })
                })

                if (!response.ok) {
                    throw new Error();
                }

                loadBooksBtn.click();
            } catch (error) {
                console.log('Error submitting!');
            }
        }
    } else {
        console.log('Input must be non-empty!');
    }
});

loadBooksBtn.addEventListener('click', async (e) => {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();
        document.querySelector('table tbody').innerHTML = '';

        Object.values(data).forEach(element => {
            let rowElement = document.createElement('tr');
            rowElement.innerHTML =
                `<td>${element.title}</td>
                <td>${element.author}</td>
                <td>
                    <button onclick="editOnClick(event)">Edit</button>
                    <button onclick="deleteOnClick(event)">Delete</button>
                </td>`;
            document.querySelector('table tbody').appendChild(rowElement);
        });
    } catch (error) {
        console.log('Error loading!');
    }
});

async function editOnClick(e) {
    let form = document.querySelector('form');
    form.querySelector('h3').textContent = 'Edit FORM';
    form.querySelector('button').textContent = 'Save';

    let rowElement = e.currentTarget.parentElement.parentElement;
    let bookTitle = rowElement.querySelectorAll('td')[0].textContent;
    let bookAuthor = rowElement.querySelectorAll('td')[1].textContent;
    currentEditBookId = await getBookId(bookTitle, bookAuthor);
}

async function deleteOnClick(e) {
    let rowElement = e.currentTarget.parentElement.parentElement;
    let bookTitle = rowElement.querySelectorAll('td')[0].textContent;
    let bookAuthor = rowElement.querySelectorAll('td')[1].textContent;
    let id = await getBookId(bookTitle, bookAuthor);

    try {
        let response = await fetch(`${url}/${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })

        if (!response.ok) {
            throw new Error();
        }

        loadBooksBtn.click();
    } catch (error) {
        console.log('Error deleting!');
    }
}

async function getBookId(title, author) {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();
        let book = Object.entries(data).find(x => x[1].title === title && x[1].author === author);

        if (book) {
            return book[0];
        }
    } catch (error) {
        console.log('Error getting id!');
    }
}
