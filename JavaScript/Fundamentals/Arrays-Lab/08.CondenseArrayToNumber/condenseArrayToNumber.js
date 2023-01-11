function condenseArrayToNumber(arr) {
    function condense(array) {
        if (array.length === 1) {
            return array[0];
        }

        let condensedArr = [];

        for (let i = 0; i < array.length - 1; i++) {
            condensedArr.push(array[i] + array[i + 1]);
        }

        return condense(condensedArr);
    }

    console.log(condense(arr));
}
