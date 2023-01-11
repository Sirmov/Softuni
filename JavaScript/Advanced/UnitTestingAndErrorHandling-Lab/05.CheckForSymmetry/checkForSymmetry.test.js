const { expect } = require('chai');
const { it } = require('mocha');
const isSymmetric = require('./checkForSymmetry');

describe('Unit tests for isSymmetric function', () => {
    it('Should return false if input is a string', () => {
        expect(isSymmetric('test')).to.be.false;
    });

    it('Should return false if input is a number', () => {
        expect(isSymmetric(-15.6)).to.be.false;
    });

    it('Should return false if input is an object', () => {
        expect(isSymmetric({})).to.be.false;
    });

    it('Should return false if no parameters are passed', () => {
        expect(isSymmetric()).to.be.false;
    });

    it('Should return true if array is symmetric', () => {
        expect(isSymmetric([1, 1, 1, 1])).to.be.true;
        expect(isSymmetric([1, 6, 6, 1])).to.be.true;
        expect(isSymmetric([{}, {}])).to.be.true;
        expect(isSymmetric([])).to.be.true;
    });

    it('Should return false if array is not symmetric', () => {
        expect(isSymmetric([1, 2, 3, 4])).to.be.false;
        expect(isSymmetric([4, 2, {}, 4])).to.be.false;
        expect(isSymmetric([4, 3, 2, []])).to.be.false;
    });
});
