function solve(input) {
    let numbers = [];

    while (input.length > 0) {
        let element = input.shift();
        if (Number(element)) {
            numbers.push(Number(element));
        } else {
            if (numbers.length < 2) {
                console.log('Error: not enough operands!');
                return;
            }

            let secondOperand = numbers.pop();
            let firstOperand = numbers.pop();

            switch (element) {
                case '+':
                    input.unshift(firstOperand + secondOperand);
                    break;
                case '-':
                    input.unshift(firstOperand - secondOperand);
                    break;
                case '*':
                    input.unshift(firstOperand * secondOperand);
                    break;
                case '/':
                    input.unshift(firstOperand / secondOperand);
                    break;
                default:
                    break;
            }
        }
    }

    if (numbers.length > 1) {
        console.log('Error: too many operands!');
        return;
    }

    console.log(numbers.pop());
}
