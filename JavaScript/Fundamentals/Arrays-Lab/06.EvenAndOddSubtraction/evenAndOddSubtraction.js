function evenAndOddSubtraction(arr) {
    let evenNumbers = arr.filter(x => x % 2 == 0);
    let oddNumbers = arr.filter(x => x % 2 != 0);

    let evenSum = evenNumbers.length === 0 ?
        0 : evenNumbers.reduce((x, y) => x + y);
    let oddSum = oddNumbers.length === 0 ?
        0 : oddNumbers.reduce((x, y) => x + y);

    console.log(evenSum - oddSum);
}
