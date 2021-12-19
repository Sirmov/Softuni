function maxNumber(arr) {
    let topIntegers = [];

    for (let i = 0; i < arr.length; i++) {
        let element = arr[i];
        let isTop = true;

        for (let j = i + 1; j < arr.length; j++) {
            if (element <= arr[j]) {
                isTop = false;
            }
        }

        if (isTop) {
            topIntegers.push(element);
        }
    }

    console.log(topIntegers.join(' '));
}
