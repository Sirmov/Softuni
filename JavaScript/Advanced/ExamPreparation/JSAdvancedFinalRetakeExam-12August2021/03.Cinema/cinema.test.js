const { expect } = require('chai');
const cinema = require('./cinema');

describe('Unit tests for cinema object', () => {
    describe('Unit test for showMovies function', () => {
        it('Should return the movies separated by a comma and a space', () => {
            let movies = ['King Kong', 'Spiderman', 'All Tomorows'];
            expect(cinema.showMovies(movies)).to.equal('King Kong, Spiderman, All Tomorows');
        });

        it('Should return "There are currently no movies to show." if array is empty', () => {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        })
    });

    describe('Unit tests for ticketPrice function', () => {
        it('Should throw if projectionType is not present', () => {
            expect(() => cinema.ticketPrice('test')).to.throw('Invalid projection type.');
        });

        it('Should return 12.00 for Premiere', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        });

        it('Should return 7.50 for Normal', () => {
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        });

        it('Should return 5.50 for Discount', () => {
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        });
    });

    describe('Unit test for swapSeatsInHall function', () => {
        it('Should be unsuccessful when one of the numbers does not exist', () => {
            expect(cinema.swapSeatsInHall(1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall()).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should be unsuccessful if the numbers are not integers', () => {
            expect(cinema.swapSeatsInHall(1, {})).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1.15, 16.322)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should be unsuccessful if the numbers less or equal to 0', () => {
            expect(cinema.swapSeatsInHall(0, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 0)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-1, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, -1)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should be unsuccessful if the numbers are greater then 20', () => {
            expect(cinema.swapSeatsInHall(21, 1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 21)).to.equal('Unsuccessful change of seats in the hall.');
        });

        it('Should be successful if numbers are between 1 and 20 integers', () => {
            expect(cinema.swapSeatsInHall(1, 15)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(15, 20)).to.equal('Successful change of seats in the hall.');
        })
    });
});
