function solve(arr) {
    let sortedArr = [];
    arr.sort((a, b) => a - b);

    while (arr.length > 0) {
        sortedArr.push(arr.shift());
        sortedArr.push(arr.pop());
    }

    return sortedArr;
}
