const { expect } = require('chai');
const testNumbers = require('./testNumbers');

describe('Unit test for testNumber object', () => {
    describe('Unit test for sumNumber function', () => {
        it('Should return undefined if parameters are not numbers', () => {
            expect(testNumbers.sumNumbers([], [])).to.be.undefined;
            expect(testNumbers.sumNumbers({}, {})).to.be.undefined;
            expect(testNumbers.sumNumbers(true, false)).to.be.undefined;
            expect(testNumbers.sumNumbers('test1', 'test2')).to.be.undefined;
        });

        it('Should return undefined if parameters are missing', () => {
            expect(testNumbers.sumNumbers(5,)).to.be.undefined;
            expect(testNumbers.sumNumbers([])).to.be.undefined;
            expect(testNumbers.sumNumbers(5)).to.be.undefined;
        });

        it('Should return sum of numbers', () => {
            expect(testNumbers.sumNumbers(5, 5)).to.equal('10.00');
            expect(testNumbers.sumNumbers(15, 5)).to.equal('20.00');
        });

        it('Should work with negative numbers', () => {
            expect(testNumbers.sumNumbers(10, -5)).to.equal('5.00');
            expect(testNumbers.sumNumbers(-15, -5)).to.equal('-20.00');
        });

        it('Should work with float numbers with precision to the second digit', () => {
            expect(testNumbers.sumNumbers(10.557, -5.001)).to.equal('5.56');
            expect(testNumbers.sumNumbers(-15.005, -5.005)).to.equal('-20.01');
        });
    });

    describe('Unit test for numberChecker function', () => {
        it('Should throw an error in parameter is not a number', () => {
            expect(() => testNumbers.numberChecker('test')).to.throw('The input is not a number!');
        });

        it('Should return "The number is odd!" if the number is odd', () => {
            expect(testNumbers.numberChecker(7)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(13)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(-3)).to.equal('The number is odd!');
        });

        it('Should return "The number is even!" if the number is odd', () => {
            expect(testNumbers.numberChecker(0)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(4)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(-22)).to.equal('The number is even!');
        });
    });

    describe('Unit test for averageSumArray function', () => {
        it('Should return the average sum of the array', () => {
            let array = [5, 15, -6, 3.22, -0.228];
            let expected = array.reduce((a, x) => a + x, 0) / array.length;

            expect(testNumbers.averageSumArray(array)).to.deep.equal(expected);
        });
    });
});
