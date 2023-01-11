const { expect } = require('chai');
const flowerShop = require('./flowerShop');

describe('Unit test for flowerShop object', () => {
    describe('Unit tests for calcPriceOfFlowers function', () => {
        it('Should throw an error if input is not the correct type', () => {
            expect(() => flowerShop.calcPriceOfFlowers(false, 5, 5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('test', 5, [])).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('test', {}, 5)).to.throw('Invalid input!');
        });

        it('Should throw an error if numbers are not integers', () => {
            expect(() => flowerShop.calcPriceOfFlowers('test', 5.55, 5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('test', 5, 5.55)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('test', 5.55, 5.55)).to.throw('Invalid input!');
        });

        it('Should return the product of the price and the quantity rounded to the second digit', () => {
            let expected = `You need $${(5 * 5).toFixed(2)} to buy test!`;
            expect(flowerShop.calcPriceOfFlowers('test', 5, 5)).to.equal(expected);
        });
    });

    describe('Unit test for checkFlowersAvailable function', () => {
        let flowers = ['Poppy', 'Daffodil', 'Dahlias'];

        it('Should return available', () => {
            expect(flowerShop.checkFlowersAvailable('Poppy', flowers)).to.equal('The Poppy are available!')
            expect(flowerShop.checkFlowersAvailable('Dahlias', flowers)).to.equal('The Dahlias are available!')
            expect(flowerShop.checkFlowersAvailable('Daffodil', flowers)).to.equal('The Daffodil are available!')
        });

        it('Should return sold', () => {
            expect(flowerShop.checkFlowersAvailable('Rose', flowers)).to.equal('The Rose are sold! You need to purchase more!')
            expect(flowerShop.checkFlowersAvailable('Rose', [])).to.equal('The Rose are sold! You need to purchase more!')
            expect(flowerShop.checkFlowersAvailable('', flowers)).to.equal('The  are sold! You need to purchase more!')
            expect(flowerShop.checkFlowersAvailable('', [])).to.equal('The  are sold! You need to purchase more!')
        });
    });

    describe('Unit tests for sellFlowers function', () => {
        it('Should throw an error if array is not the correct type', () => {
            expect(() => flowerShop.sellFlowers({}, 5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers('test', 5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(false, 5)).to.throw('Invalid input!');
        });

        it('Should throw an error if number is not the correct type', () => {
            expect(() => flowerShop.sellFlowers([], true)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], {})).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], [])).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], '')).to.throw('Invalid input!');
        });

        it('Should throw an error if number is not an integer', () => {
            expect(() => flowerShop.sellFlowers([], 5.5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], -5.5)).to.throw('Invalid input!');
        });

        it('Should throw an error if number out of range', () => {
            expect(() => flowerShop.sellFlowers([1, 2, 3], 4)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([1, 2, 3], -1)).to.throw('Invalid input!');
        });

        it('Should return the array joined by  /  without the remove element', () => {
            let flowers = ['Poppy', 'Daffodil', 'Dahlias'];
            expect(flowerShop.sellFlowers(flowers, 0)).to.equal('Daffodil / Dahlias');
            expect(flowerShop.sellFlowers(flowers, 1)).to.equal('Poppy / Dahlias');
            expect(flowerShop.sellFlowers(flowers, 2)).to.equal('Poppy / Daffodil');
        });
    });
});
