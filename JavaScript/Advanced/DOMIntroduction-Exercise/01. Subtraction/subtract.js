function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');

    let firstNum = Number(firstNumberElement.value);
    let secondNum = Number(secondNumberElement.value);

    let result = firstNum - secondNum;

    let resultElement = document.getElementById('result');
    resultElement.textContent = result;
}
