function addItem() {
    let inputTextElement = document.getElementById('newItemText');
    let inputValueElement = document.getElementById('newItemValue');
    let text = inputTextElement.value;
    let value = inputValueElement.value;
    inputTextElement.value = '';
    inputValueElement.value = '';

    let optionElement = document.createElement('option');
    optionElement.textContent = text;
    optionElement.value = value;

    let selectMenuElement = document.getElementById('menu');
    selectMenuElement.appendChild(optionElement);
}
