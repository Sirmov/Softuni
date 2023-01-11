const { expect } = require('chai');
const rgbToHexColor = require('./rgb-to-hex');

describe('Unit tests for rgbToHexColor function', () => {
    it('Should return undefined when parameters are not numbers', () => {
        expect(rgbToHexColor({}, {}, {})).to.be.undefined;
        expect(rgbToHexColor([], [], [])).to.be.undefined;
        expect(rgbToHexColor(true, true, true)).to.be.undefined;
        expect(rgbToHexColor('test', 'test', 'test')).to.be.undefined;
    });

    it('Should return undefined when parameters are out of range (0-255)', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
    });

    it('Should return undefined when parameters are missing', () => {
        expect(rgbToHexColor()).to.be.undefined;
        expect(rgbToHexColor(255)).to.be.undefined;
        expect(rgbToHexColor(255, 255)).to.be.undefined;
    });

    it('Should return the same color in hexadecimal format when parameters are correct', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
        expect(rgbToHexColor(58, 199, 107)).to.equal('#3AC76B');
    });
});
