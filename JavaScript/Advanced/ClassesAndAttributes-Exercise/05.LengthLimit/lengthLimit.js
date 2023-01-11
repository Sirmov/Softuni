class Stringer {
    constructor(initialString, initialLength) {
        this.innerString = initialString;
        this.innerLength = initialLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let length = Math.min(this.innerLength, this.innerString.length);
        let output = this.innerString.split('').slice(0, length).join('');

        if (this.innerLength < this.innerString.length) {
            output += '...';
        }

        return output;
    }
}
