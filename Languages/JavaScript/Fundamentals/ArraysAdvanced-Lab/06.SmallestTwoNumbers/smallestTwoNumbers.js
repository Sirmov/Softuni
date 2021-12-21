function smallestTwoNumbers(arr) {
    arr.sort((a, b) => a - b);
    console.log(arr.slice(0, 2).join(' '));
}
