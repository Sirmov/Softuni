function maxSequenceOfEqualElements(arr) {
    let maxLength = 0;
    let maxElement;

    for (let i = 0; i < arr.length; i++) {
        let element = arr[i];
        let length = 1;

        while (element === arr[i + length]) {
            length++;
        }

        if (length > maxLength) {
            maxLength = length;
            maxElement = element;
        }
    }

    console.log(Array(maxLength).fill(maxElement).join(' '));
}
