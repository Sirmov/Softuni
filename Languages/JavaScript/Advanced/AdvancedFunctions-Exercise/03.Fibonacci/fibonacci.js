function getFibonator() {
    let sequence = [0, 1];

    return function nextNumber() {
        sequence.push(sequence.slice(-2).reduce((a, c) => a + c));
        return sequence[sequence.length - 2];
    }
}
