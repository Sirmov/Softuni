function rightPlace(originalString, missingChar, expectedResult) {
    let result = (originalString).replace('_', missingChar);

    if (result === expectedResult) {
        console.log('Matched');
    } else {
        console.log('Not Matched');
    }
}