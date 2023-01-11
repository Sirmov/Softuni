function solve(arr, step) {
    let output = [];

    for (let i = 0; i < arr.length; i += step) {
        output.push(arr[i]);
    }

    return output;
}
