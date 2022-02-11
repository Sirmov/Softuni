(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        } else {
            return this.toString();
        }
    }

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        } else {
            return this.toString();
        }
    }

    String.prototype.isEmpty = function () {
        return this.length === 0;
    }

    String.prototype.truncate = function (n) {
        if(Number(n) < 4) {

            return ".".repeat(Number(n));

        }

        if (Number(n) >= this.length) {
                
            return this.toString();

        }

        let lastWhitespace = this.toString().substring(0, n - 2).lastIndexOf(" ");

        return lastWhitespace !== -1
            ? `${this.toString().substring(0, lastWhitespace)}...`
            : `${this.toString().substring(0, n - 3)}...`;
    }

    String.format = function (string, ...params) {
        return string.replace(/{([0-9]+)}/g, function (match, index) {
            return typeof params[index] == 'undefined' ? match : params[index];
        });
    }
})()

let str = 'my string';
console.log(str);
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);
