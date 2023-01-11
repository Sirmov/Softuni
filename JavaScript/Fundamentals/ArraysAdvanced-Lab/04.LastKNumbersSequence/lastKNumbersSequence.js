function lastKNumbersSequence(length, k) {
    let sequence = Array.of(1);

    for (let i = 1; i < length; i++) {
        let start = i - k < 0 ? 0 : i - k;
        let previousElements = sequence.slice(start, i);
        let sum = previousElements.reduce((a, b) => a + b);
        sequence[i] = sum;
    }

    console.log(sequence.join(' '));
}
