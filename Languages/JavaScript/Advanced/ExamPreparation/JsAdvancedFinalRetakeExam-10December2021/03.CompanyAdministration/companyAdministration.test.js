const { expect } = require('chai');
const companyAdministration = require('./companyAdministration');

describe('Unit tests for companyAdministration object', () => {
    describe('Unit tests for hiringEmployee function', () => {
        it('Should throw an error if position is not Programmer', () => {
            expect(() => companyAdministration.hiringEmployee('', 'Cook', 5))
                .to.throw('We are not looking for workers for this position.');
            expect(() => companyAdministration.hiringEmployee('', 'Driver', 5))
                .to.throw('We are not looking for workers for this position.');
        });

        it('Should hire if experience is equal or above 3 years', () => {
            expect(companyAdministration.hiringEmployee('test1', 'Programmer', 3))
                .to.equal('test1 was successfully hired for the position Programmer.');
            expect(companyAdministration.hiringEmployee('test2', 'Programmer', 5))
                .to.equal('test2 was successfully hired for the position Programmer.');
            expect(companyAdministration.hiringEmployee('test3', 'Programmer', 10))
                .to.equal('test3 was successfully hired for the position Programmer.');
        });

        it('Should not hire if experience is less than 3 years', () => {
            expect(companyAdministration.hiringEmployee('test1', 'Programmer', 2))
                .to.equal('test1 is not approved for this position.');
            expect(companyAdministration.hiringEmployee('test2', 'Programmer', 1))
                .to.equal('test2 is not approved for this position.');
            expect(companyAdministration.hiringEmployee('test3', 'Programmer', 0))
                .to.equal('test3 is not approved for this position.');
        });
    });

    describe('Unit tests for calculateSalary function', () => {
        it('Should throw an error if hours are not a number', () => {
            expect(() => companyAdministration.calculateSalary([])).to.throw('Invalid hours');
            expect(() => companyAdministration.calculateSalary({})).to.throw('Invalid hours');
            expect(() => companyAdministration.calculateSalary(true)).to.throw('Invalid hours');
        });

        it('Should throw an error if hours negative', () => {
            expect(() => companyAdministration.calculateSalary(-1)).to.throw('Invalid hours');
            expect(() => companyAdministration.calculateSalary(-5)).to.throw('Invalid hours');
            expect(() => companyAdministration.calculateSalary(-50)).to.throw('Invalid hours');
        });

        it('Should calculate the salary by multiplying 15 by the number of hours', () => {
            expect(companyAdministration.calculateSalary(10)).to.equal(150);
            expect(companyAdministration.calculateSalary(5)).to.equal(75);
            expect(companyAdministration.calculateSalary(1)).to.equal(15);
            expect(companyAdministration.calculateSalary(0)).to.equal(0);
        });

        it('Should give bonus(1000) if hours are more than 160', () => {
            expect(companyAdministration.calculateSalary(200)).to.equal(4000);
            expect(companyAdministration.calculateSalary(161)).to.equal(3415);
        });
    });

    describe('Unit tests for firedEmployee function', () => {
        it('Should throw an error if employees is not an array', () => {
            expect(() => companyAdministration.firedEmployee({}, 5)).to.throw('Invalid input');
            expect(() => companyAdministration.firedEmployee(false, 5)).to.throw('Invalid input');
        });

        it('Should throw an error if index is not a number', () => {
            expect(() => companyAdministration.firedEmployee([], true)).to.throw('Invalid input');
            expect(() => companyAdministration.firedEmployee([1, 2, 3], [])).to.throw('Invalid input');
        });

        it('Should throw an error if index is out of range', () => {
            expect(() => companyAdministration.firedEmployee([], 1)).to.throw('Invalid input');
            expect(() => companyAdministration.firedEmployee([1, 2, 3], 3)).to.throw('Invalid input');
            expect(() => companyAdministration.firedEmployee([1, 2, 3], -1)).to.throw('Invalid input');
        });

        it('Should remove employee at given index', () => {
            let employees = ['Petar', 'Ivan', 'George'];
            expect(companyAdministration.firedEmployee(employees, 0)).to.equal('Ivan, George');
            expect(companyAdministration.firedEmployee(employees, 1)).to.equal('Petar, George');
            expect(companyAdministration.firedEmployee(employees, 2)).to.equal('Petar, Ivan');
        });
    });
});
