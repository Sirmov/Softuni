function solve() {
    let innerString = '';

    return {
        append(string) {
            innerString += string;
        },
        removeStart(n) {
            innerString = innerString.slice(n);
        },
        removeEnd(n) {
            innerString = innerString.slice(0, innerString.length - n);
        },
        print() {
            console.log(innerString);
        }
    }
}
