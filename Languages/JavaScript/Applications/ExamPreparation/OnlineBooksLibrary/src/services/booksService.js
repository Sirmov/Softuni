import * as httpClient from '../utils/httpClient.js';

const endpoints = {
    books: '/data/books',
    allBooks: '/data/books?sortBy=_createdOn%20desc',
    book: (bookId) => `/data/books/${bookId}`,
    myBooks: (userId) => `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
}

export function createBook(book) {
    return httpClient.post(endpoints.books, book);
}

export function readAllBooks() {
    return httpClient.get(endpoints.allBooks);
}

export function readBook(bookId) {
    return httpClient.get(endpoints.book(bookId));
}

export function updateBook(bookId, book) {
    return httpClient.put(endpoints.book(bookId), book);
}

export function deleteBook(bookId) {
    return httpClient.del(endpoints.book(bookId));
}

export function readMyBooks(userId) {
    return httpClient.get(endpoints.myBooks(userId));
}
