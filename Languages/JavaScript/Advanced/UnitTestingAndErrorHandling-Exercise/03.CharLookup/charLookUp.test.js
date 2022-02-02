const { expect } = require('chai');
const lookupChar = require('./charLookUp');

describe('Unit test for lookupChar function', () => {
    it('Should return undefined when first parameters in not string', () => {
        expect(lookupChar(5, 5)).to.be.undefined;
        expect(lookupChar(false, 5)).to.be.undefined;
        expect(lookupChar({}, 5)).to.be.undefined;
    });

    it('Should return undefined when second parameters in not an integer', () => {
        expect(lookupChar('test', false)).to.be.undefined;
        expect(lookupChar('test', [])).to.be.undefined;
        expect(lookupChar('test', 5.66)).to.be.undefined;
    });

    it('Should return "Incorrect index" when index is out range', () => {
        expect(lookupChar('test', -1)).to.equal('Incorrect index');
        expect(lookupChar('test', 4)).to.equal('Incorrect index');
        expect(lookupChar('test', 6)).to.equal('Incorrect index');
    });

    it('Should return character at corresponding index', () => {
        expect(lookupChar('test', 0)).to.equal('t');
        expect(lookupChar('test', 3)).to.equal('t');
        expect(lookupChar('Nikola', 0)).to.equal('N');
        expect(lookupChar('Nikola', 5)).to.equal('a');
    });
});
