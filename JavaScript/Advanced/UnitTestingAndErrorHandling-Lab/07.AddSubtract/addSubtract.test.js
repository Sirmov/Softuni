const { expect } = require('chai');
const createCalculator = require('./addSubtract');

describe('Unit test for createCalculator function', () => {
    it('Should return a object', () => {
        let result = createCalculator();
        expect(result).to.be.an('object');
    });

    it('Should return an object with add, subtract and get properties', () => {
        let result = createCalculator();
        expect(result).to.haveOwnProperty('add');
        expect(result).to.haveOwnProperty('subtract');
        expect(result).to.haveOwnProperty('get');
    });

    it('Should return an object with add, subtract and get properties which are functions', () => {
        let result = createCalculator();
        expect(result.add).to.be.a('function');
        expect(result.subtract).to.be.a('function');
        expect(result.get).to.be.a('function');
    });

    it('Should keep sum value in a closure', () => {
        let result = createCalculator();
        expect(result).to.not.haveOwnProperty('value');
        expect(result).to.not.haveOwnProperty('sum');
        expect(result).to.not.haveOwnProperty('internalSum');
        expect(result).to.not.haveOwnProperty('innerSum');
    });

    describe('Unit tests for calculator object', () => {
        describe('Unit tests for add function', () => {
            it('Should add the given number to the sum', () => {
                let result = createCalculator();
                result.add(5);
                result.add(-1);
                result.add(0);
                result.add(0.5);
                expect(result.get()).to.equal(4.5);
            });

            it('Should work with numbers as strings', () => {
                let result = createCalculator();
                result.add('5');
                result.add('-1');
                result.add('0');
                result.add('0.5');
                expect(result.get()).to.equal(4.5);
            });
        });

        describe('Unit tests for subtract function', () => {
            it('Should subtract the given number to the sum', () => {
                let result = createCalculator();
                result.add(5);
                result.subtract(-1);
                result.subtract(0);
                result.subtract(0.5);
                expect(result.get()).to.equal(5.5);
            });

            it('Should work with numbers as strings', () => {
                let result = createCalculator();
                result.add('5');
                result.subtract('-1');
                result.subtract('0');
                result.subtract('0.5');
                expect(result.get()).to.equal(5.5);
            });
        });

        describe('Unit tests for get function', () => {
            it('Should return the accumulated sum', () => {
                let result = createCalculator();
                result.add(5);
                expect(result.get()).to.equal(5);
                result.add(-1);
                expect(result.get()).to.equal(4);
                result.add(0);
                expect(result.get()).to.equal(4);
                result.add(0.5);
                expect(result.get()).to.equal(4.5);
            });

            it('Should work with numbers as strings', () => {
                let result = createCalculator();
                result.add('5');
                expect(result.get()).to.equal(5);
                result.subtract('-1');
                expect(result.get()).to.equal(6);
                result.subtract('0');
                expect(result.get()).to.equal(6);
                result.subtract('0.5');
                expect(result.get()).to.equal(5.5);
            });
        });
    });
});
