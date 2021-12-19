function arrayRotation(arr, rotations) {
    // for (let i = 0; i < rotations; i++) {
    //     arr.push(arr.shift());
    // }

    for (let i = 0; i < rotations; i++) {
        let first = arr[0];

        for (let j = 0; j < arr.length - 1; j++) {
            arr[j] = arr[j + 1];
        }

        arr[arr.length - 1] = first;
    }

    console.log(arr.join(' '));
}