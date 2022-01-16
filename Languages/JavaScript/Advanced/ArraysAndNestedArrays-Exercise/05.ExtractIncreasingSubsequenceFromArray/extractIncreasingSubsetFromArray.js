function solve(arr) {
    let biggest = Number.MIN_SAFE_INTEGER;
    let subset = [];

    for (const element of arr) {
        if (element >= biggest) {
            biggest = element;
            subset.push(element);
        }
    }

    return subset;
}
