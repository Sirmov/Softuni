function solve(numbers, start, end) {
    if (!Array.isArray(numbers)) {
        return NaN;
    }

    let startIndex = start < 0 ? 0 : start;
    let endIndex = end >= numbers.length ? numbers.length - 1 : end;

    return numbers.slice(startIndex, endIndex + 1).reduce((a, x) => a + Number(x), 0);
}
