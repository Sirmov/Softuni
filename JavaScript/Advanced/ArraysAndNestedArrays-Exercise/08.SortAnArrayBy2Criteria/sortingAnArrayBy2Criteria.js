function solve(arr) {
    arr
        .sort((a, b) => a.length - b.length || a.localeCompare(b));

    for (const element of arr) {
        console.log(element);
    }
}
