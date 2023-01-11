function commonElements(firstArr, secondArr) {
    for (let i = 0; i < firstArr.length; i++) {
        let element = firstArr[i];

        for (let j = 0; j < secondArr.length; j++) {
            if (element === secondArr[j]) {
                console.log(element);
            }
        }
    }
}
