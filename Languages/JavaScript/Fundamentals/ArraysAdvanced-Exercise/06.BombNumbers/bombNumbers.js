function bombNumbers(numbers, bombInfo) {
    let bomb = bombInfo[0];
    let power = bombInfo[1];

    for (let i = 0; i < numbers.length; i++) {
        if (numbers[i] === bomb) {
            let start = i - power < 0 ? 0 : i - power;
            numbers.splice(start, power * 2 + 1);
            i = start - 1;
        }
    }

    let sum = numbers.length === 0 ?
        0 : numbers.reduce((a, b) => a + b);

    console.log(sum);
}
