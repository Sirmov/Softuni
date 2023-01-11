function sumOfOddNumbers(n) {
    let sum = 0;
    let num = -1;

    for (let i = 0; i < n; i++) {
        sum += num += 2;
        console.log(num);
    }

    console.log(`Sum: ${sum}`);
}
