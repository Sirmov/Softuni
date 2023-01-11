const { expect } = require('chai');
const library = require('./library');


describe('Unit tests for library object', () => {
    describe('Unit tests for calcPriceOfBook function', () => {
        it('Should throw an error if nameOfBook is not a string', () => {
            expect(() => library.calcPriceOfBook([], 2000)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook({}, 2000)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(true, 2000)).to.throw('Invalid input');
        });

        it('Should throw an error if year is not an integer', () => {
            expect(() => library.calcPriceOfBook('test', true)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('test', {})).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('test', 5.55)).to.throw('Invalid input');
        });

        it('Should throw an error if parameters are missing', () => {
            expect(() => library.calcPriceOfBook('test')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook()).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(5.55)).to.throw('Invalid input');
        });

        it('Should return 20bgn if book is newer than 1980', () => {
            expect(library.calcPriceOfBook('test', 1981)).to.equal('Price of test is 20.00');
            expect(library.calcPriceOfBook('test', 2000)).to.equal('Price of test is 20.00');
            expect(library.calcPriceOfBook('test', 2022)).to.equal('Price of test is 20.00');
        });

        it('Should return apply discount if book is older than 1981', () => {
            expect(library.calcPriceOfBook('test', 1980)).to.equal('Price of test is 10.00');
            expect(library.calcPriceOfBook('test', 1000)).to.equal('Price of test is 10.00');
            expect(library.calcPriceOfBook('test', 1887)).to.equal('Price of test is 10.00');
        });
    });

    describe('Unit test for findBook function', () => {
        it('Should throw an error if an empty array is passed', () => {
            expect(() => library.findBook([], 'test')).to.throw('No books currently available');
        });

        it('Should return "We found the book you want." if the book is present', () => {
            expect(library.findBook(['test1', 'test2', 'test3'], 'test1')).to.equal('We found the book you want.')
        });

        it('Should return "The book you are looking for is not here!" if the book is not present', () => {
            expect(library.findBook(['test1', 'test2', 'test3'], 'test')).to.equal('The book you are looking for is not here!')
        });
    });

    describe('Unit test for arrangeTheBooks function', () => {
        it('Should throw an error if countBooks is not an integer or negative', () => {
            expect(() => library.arrangeTheBooks(15.5)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(-1)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(-4.32)).to.throw('Invalid input');
        });

        it('Should return "Great job, the books are arranged." if books are less or equal to 40', () => {
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(0)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(20)).to.equal('Great job, the books are arranged.');
        });

        it('Should return "Insufficient space, more shelves need to be purchased." if books are more than 40', () => {
            expect(library.arrangeTheBooks(41)).to.equal('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(50)).to.equal('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(100)).to.equal('Insufficient space, more shelves need to be purchased.');
        });
    });
});
