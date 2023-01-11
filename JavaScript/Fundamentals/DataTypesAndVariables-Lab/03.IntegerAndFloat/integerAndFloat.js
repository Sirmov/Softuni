function integerAndFloat(num1, num2, num3) {
    let sum = num1 + num2 + num3;

    console.log(`${sum} - ${String(sum).includes('.') ? 'Float' : 'Integer'}`);
}
