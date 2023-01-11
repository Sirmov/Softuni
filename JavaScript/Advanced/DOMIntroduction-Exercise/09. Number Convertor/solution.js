function solve() {
    document.querySelector('div#container button').addEventListener('click', onClick);

    const binaryOption = document.createElement('option');
    binaryOption.textContent = 'Binary';
    binaryOption.value = 'binary';

    const hexadecimalOption = document.createElement('option');
    hexadecimalOption.textContent = 'Hexadecimal';
    hexadecimalOption.value = 'hexadecimal';

    document.getElementById('selectMenuTo').appendChild(binaryOption);
    document.getElementById('selectMenuTo').appendChild(hexadecimalOption);

    function onClick() {
        let decimalNumber = Number(document.getElementById('input').value);
        let optionIndex = document.getElementById('selectMenuTo').selectedIndex;
        let optionValue = document.getElementById('selectMenuTo').value;

        let outputElement = document.getElementById('result');

        if (optionValue === 'binary' || optionIndex === 0) {
            outputElement.value = decimalNumber.toString(2);
        } else if (optionValue === 'hexadecimal' || optionIndex === 1) {
            outputElement.value = decimalNumber.toString(16).toUpperCase();
        }
    }
}
