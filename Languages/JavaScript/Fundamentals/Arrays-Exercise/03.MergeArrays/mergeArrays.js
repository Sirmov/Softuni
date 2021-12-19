function mergeArrays(firstArr, secondArr) {
    let mergedArray = [];

    for (let i = 0; i < firstArr.length; i++) {
        if (i % 2 == 0) {
            mergedArray.push(Number(firstArr[i]) + Number(secondArr[i]));
        } else {
            mergedArray.push(firstArr[i] + secondArr[i]);
        }
    }

    console.log(mergedArray.join(' - '));
}