function processOddNumbers(arr) {
    console.log(arr.filter((x, i) => i % 2 !== 0)
        .reverse()
        .map(x => x * 2)
        .join(' '));
}
