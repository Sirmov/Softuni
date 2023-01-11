const { expect } = require('chai');
const sum = require('./sumOfNumbers');

describe('Unit tests for sum function', () => {
    it('Should return the zero if the array is empty', () => {
        expect(sum([])).to.equal(0);
    });

    it('Should work with numbers in string format', () => {
        expect(sum(['1', '2', '3', '4', '5'])).to.equal(15);
        expect(sum(['1', '2', '-3', '4', '5'])).to.equal(9);
        expect(sum(['1', '2', '3.5', '4', '5'])).to.equal(15.5);
    });

    it('Should return the sum of the numbers in the array', () => {
        expect(sum([1, 2, 3, 4, 5])).to.equal(15);
        expect(sum([1, 2, -3, 4, 5])).to.equal(9);
        expect(sum([1, 2, 3.5, 4, 5])).to.equal(15.5);
    });
});
