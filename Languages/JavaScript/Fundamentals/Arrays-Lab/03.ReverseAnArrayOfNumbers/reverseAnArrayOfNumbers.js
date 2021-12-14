function reverseAnArrayOfNumbers(n, array) {
    let outputElements = [];

    for (let i = 0; i < n; i++) {
        outputElements.push(array[i]);
    }

    let reversedOutput = [];

    for (let i = outputElements.length - 1; i >= 0; i--) {
        reversedOutput.push(outputElements[i]);
    }

    console.log(reversedOutput.join(" "));
}
