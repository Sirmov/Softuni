function magicSum(arr, magicSum) {
    for (let i = 0; i < arr.length; i++) {
        for (let j = i + 1; j < arr.length; j++) {
            let sum = arr[i] + arr[j];

            if (sum === magicSum) {
                console.log(`${arr[i]} ${arr[j]}`);
            }
        }
    }
}
