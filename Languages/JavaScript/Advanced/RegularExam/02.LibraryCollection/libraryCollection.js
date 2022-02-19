class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length === this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        this.books.push({ bookName, bookAuthor, payed: false });
        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let book = this.books.find(x => x.bookName === bookName);

        if (!book) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (book.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let book = this.books.find(x => x.bookName === bookName);

        if (!book) {
            throw new Error("The book, you're looking for, is not found.");
        }

        if (!book.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`)
        }

        this.books.splice(this.books.indexOf(book), 1);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let output = '';

        if (bookAuthor) {
            let book = this.books.find(x => x.bookAuthor === bookAuthor);

            if (!book) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            return `${book.bookName} == ${bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.`;
        } else {
            output += `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;
            output += this.books
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .map(x => `${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.`)
                .join('\n');
            return output;
        }
    }
}
