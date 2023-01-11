function sumDigits(num) {
    let sum = 0;

    while (num !== 0) {
        sum += num % 10;
        num = Math.trunc(num / 10);
    }

    console.log(sum);
}
