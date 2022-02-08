function solve(num) {
    let firstOperand = num;

    return function (num) {
        return firstOperand + num;
    }
}
