function sumEvenNumbers(arr) {
    let evenNumbers = arr.map(Number).filter(x => x % 2 == 0);
    let sum = evenNumbers.length == 0 ? 0 : evenNumbers.reduce((x, y) => x + y);
    console.log(sum);
}
