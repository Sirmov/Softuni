const { expect } = require('chai');
const isOddOrEven = require('./isOddOrEven');

describe('Unit test for isOddOrEven function', () => {
    it('Should return undefined when argument is not string', () => {
        expect(isOddOrEven(5)).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven(false)).to.be.undefined;
    });

    it('Should return even when string length is even', () => {
        expect(isOddOrEven('Nikola')).to.equal('even');
        expect(isOddOrEven('Kola')).to.equal('even');
        expect(isOddOrEven('')).to.equal('even');
    });

    it('Should return odd when string length is odd', () => {
        expect(isOddOrEven('Three')).to.equal('odd');
        expect(isOddOrEven('Sir')).to.equal('odd');
        expect(isOddOrEven('1')).to.equal('odd');
    })
});
