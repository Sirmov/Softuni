const { expect } = require('chai');
const PaymentPackage = require('./paymentPackage');

describe('Unit test for PaymentPackage class', () => {
    describe('Unit test for constructor', () => {
        it('Should initialize and return a object', () => {
            let result = new PaymentPackage('test', 0);
            expect(result).to.be.an('object');
        });

        it('Should initialize and return a object with assigned values', () => {
            let result = new PaymentPackage('test', 0);
            expect(result.name).to.equal('test');
            expect(result.value).to.equal(0);
        });

        it('Should initialize and return a object with default values', () => {
            let result = new PaymentPackage('test', 0);
            expect(result.VAT).to.equal(20);
            expect(result.active).to.be.true;
        });

        it('Should throw an error when name is not a string', () => {
            expect(() => new PaymentPackage(['test'], 0)).to.throw('Name must be a non-empty string');
        });

        it('Should throw an error when name is an empty string', () => {
            expect(() => new PaymentPackage('', 0)).to.throw('Name must be a non-empty string');
        });

        it('Should throw an error when value is not a number', () => {
            expect(() => new PaymentPackage('test', true)).to.throw('Value must be a non-negative number');
        });

        it('Should throw an error when value is a negative number', () => {
            expect(() => new PaymentPackage('test', -1)).to.throw('Value must be a non-negative number');
        });
    });

    describe('Unit test for VAT and active properties validation', () => {
        it('Should throw an error when VAT is not a number', () => {
            let object = new PaymentPackage('test', 0);
            expect(() => object.VAT = {}).to.throw('VAT must be a non-negative number');
        });

        it('Should throw an error when VAT is a negative number', () => {
            let object = new PaymentPackage('test', 0);
            expect(() => object.VAT = -1).to.throw('VAT must be a non-negative number');
        });

        it('Should throw an error when active is not a boolean', () => {
            let object = new PaymentPackage('test', 0);
            expect(() => object.active = 1).to.throw('Active status must be a boolean');
        });
    });

    describe('Unit test for toString function', () => {

        it('Should return a string containing an overview of the instance', () => {
            let object = new PaymentPackage('test', 0);
            let result = object.toString();
            let expected = [
                `Package: test`,
                `- Value (excl. VAT): 0`,
                `- Value (VAT 20%): 0`
            ].join('\n');

            expect(result).to.equal(expected);
        });

        it('Should add inactive when instance active prop is set to false', () => {
            let object = new PaymentPackage('test', 0);
            object.active = false;
            let result = object.toString();
            let expected = [
                `Package: test (inactive)`,
                `- Value (excl. VAT): 0`,
                `- Value (VAT 20%): 0`
            ].join('\n');

            expect(result).to.equal(expected);
        });

        it('Should calculate VAT correctly', () => {
            let object = new PaymentPackage('test', 100);
            object.active = false;
            let result = object.toString();
            let expected = [
                `Package: test (inactive)`,
                `- Value (excl. VAT): 100`,
                `- Value (VAT 20%): 120`
            ].join('\n');

            expect(result).to.equal(expected);
        });
    });
});
