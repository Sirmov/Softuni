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

        if (this.length <= n) {
            return this.toString();
        }

        let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(" ");

        return lastIndex !== -1
            ? `${this.toString().substring(0, lastIndex)}...`
            : `${this.toString().substring(0, n - 3)}...`;
    }

    String.format = function (string, ...params) {
        return string.replace(/{([0-9]+)}/g, function (match, index) {
            return typeof params[index] == 'undefined' ? match : params[index];
        });
    }
})()
