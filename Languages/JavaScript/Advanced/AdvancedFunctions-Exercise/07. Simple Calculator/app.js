function calculator() {
    let firstSelector;
    let secondSelector;
    let resultSelector;

    return {
        init(selector1, selector2, selector3) {
            firstSelector = selector1;
            secondSelector = selector2;
            resultSelector = selector3;
        },
        add() {
            let firstElement = document.querySelector(firstSelector);
            let secondElement = document.querySelector(secondSelector);
            let result = Number(firstElement.value) + Number(secondElement.value);
            document.querySelector(resultSelector).value = result;

        },
        subtract() {
            let firstElement = document.querySelector(firstSelector);
            let secondElement = document.querySelector(secondSelector);
            let result = Number(firstElement.value) - Number(secondElement.value);
            document.querySelector(resultSelector).value = result;
        }
    }
}
