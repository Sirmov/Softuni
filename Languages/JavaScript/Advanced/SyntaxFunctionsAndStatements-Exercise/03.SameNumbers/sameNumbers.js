function solve(number) {
    let numAsString = number.toString();
    let firstDigit = Number(numAsString[0]);
    let isSame = true;
    let sum = 0;

    for (let i = 0; i < numAsString.length; i++) {
        let digit = numAsString[i];

        if (digit != firstDigit) {
            isSame = false;
        }

        sum += Number(digit);
    }

    console.log(isSame);
    console.log(sum);
}
