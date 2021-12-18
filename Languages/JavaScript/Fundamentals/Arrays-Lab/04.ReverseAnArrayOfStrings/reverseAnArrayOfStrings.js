function reverseAnArrayOfStrings(arr) {
    function reverseArray(arr) {
        for (let i = 0; i < arr.length / 2; i++) {
            let oppositeIndex = arr.length - 1 - i;
            let temp = arr[i];
            arr[i] = arr[oppositeIndex];
            arr[oppositeIndex] = temp;
        }
    }

    reverseArray(arr);
    console.log(arr.join(' '));
}
