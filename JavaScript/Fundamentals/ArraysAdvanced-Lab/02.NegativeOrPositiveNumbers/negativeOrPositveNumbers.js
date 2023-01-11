function negativeOrPositiveNumbers(arr) {
    let sortedArray = [];

    for (const num of arr) {
        if (num < 0) {
            sortedArray.unshift(num);
        } else {
            sortedArray.push(num);
        }
    }

    console.log(sortedArray.join('\n'));
}
