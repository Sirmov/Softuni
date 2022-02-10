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
        if (n < 4) {
            return new Array(n + 1).join('.');
        }
        if (this.length < n) {
            return this.toString();
        } else if (!this.includes(' ')) {
            let output = this.slice(0, n - 3);
            return output + '...';
        } else {
            let words = this.split(' ');
            let length = words.reduce((a, x) => a + x.length, 0) + words.length;

            while (length > n) {
                words.pop();
                length = words.reduce((a, x) => a + x.length, 0) + words.length;
            }
            return words.join(' ') + '...';
        }
    }

    String.format = function (string, ...params) {
        // use replace to iterate over the string
        // select the match and check if related argument is present
        // if yes, replace the match with the argument
        return string.replace(/{([0-9]+)}/g, function (match, index) {
            // check if the argument is present
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
