const { expect } = require('chai');
const mathEnforcer = require('./mathEnforcer');

describe('Units test for mathEnforcer object', () => {
    describe('Unit test for addFive function', () => {
        it('Should return undefined when parameter is not a number', () => {
            expect(mathEnforcer.addFive('test')).to.be.undefined;
            expect(mathEnforcer.addFive(false)).to.be.undefined;
            expect(mathEnforcer.addFive({})).to.be.undefined;
        });

        it('Should return the parameter plus five', () => {
            expect(mathEnforcer.addFive(5)).to.be.closeTo(10, 0.01);
            expect(mathEnforcer.addFive(-15)).to.be.closeTo(-10, 0.01);
            expect(mathEnforcer.addFive(10.65)).to.be.closeTo(15.65, 0.01);
            expect(mathEnforcer.addFive(-5.25)).to.be.closeTo(-0.25, 0.01);
        });
    });

    describe('Unit test for subtractTen function', () => {
        it('Should return undefined when parameter is not a number', () => {
            expect(mathEnforcer.subtractTen('test')).to.be.undefined;
            expect(mathEnforcer.subtractTen(false)).to.be.undefined;
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
        });

        it('Should return the parameter minus ten', () => {
            expect(mathEnforcer.subtractTen(5)).to.be.closeTo(-5, 0.01);
            expect(mathEnforcer.subtractTen(-15)).to.be.closeTo(-25, 0.01);
            expect(mathEnforcer.subtractTen(10.65)).to.be.closeTo(0.65, 0.01);
            expect(mathEnforcer.subtractTen(-6.02)).to.be.closeTo(-16.02, 0.01);
        });
    });

    describe('Unit test for sum function', () => {
        it('Should return undefined when the first parameter is not a number', () => {
            expect(mathEnforcer.sum('test', 0)).to.be.undefined;
            expect(mathEnforcer.sum(false, 0)).to.be.undefined;
            expect(mathEnforcer.sum({}, 0)).to.be.undefined;
        });

        it('Should return undefined when the second parameter is not a number', () => {
            expect(mathEnforcer.sum(0, 'test')).to.be.undefined;
            expect(mathEnforcer.sum(0, false)).to.be.undefined;
            expect(mathEnforcer.sum(0, {})).to.be.undefined;
        });

        it('Should return the sum of both the parameters', () => {
            expect(mathEnforcer.sum(5, 5)).to.be.closeTo(10, 0.01);
            expect(mathEnforcer.sum(5.50, 5.50)).to.be.closeTo(11, 0.01);
            expect(mathEnforcer.sum(-5, -10)).to.be.closeTo(-15, 0.01);
            expect(mathEnforcer.sum(-5.0005, -5)).to.be.closeTo(-10.0005, 0.01);
            expect(mathEnforcer.sum(-15, 5)).to.be.closeTo(-10, 0.01);
            expect(mathEnforcer.sum(10.65, -0.01)).to.be.closeTo(10.64, 0.01);
        });
    });
});
