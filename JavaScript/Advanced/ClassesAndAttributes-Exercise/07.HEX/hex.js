class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return '0x' + this.value.toString('16').toUpperCase();
    }

    plus(number) {
        if (number instanceof Hex) {
            number = number.valueOf();
        }

        return new Hex(this.valueOf() + number);
    }

    minus(number) {
        if (number instanceof Hex) {
            number = number.valueOf();
        }

        return new Hex(this.valueOf() - number);
    }

    parse(hexadecimal) {
        return parseInt(hexadecimal, 16);
    }
}
