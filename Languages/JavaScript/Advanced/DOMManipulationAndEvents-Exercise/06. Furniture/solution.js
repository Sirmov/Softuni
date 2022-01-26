function solve() {
  let inputTextAreaElement = document.querySelector('div#exercise > textarea');
  let generateBtnElement = document.querySelector('div#exercise > button:first-of-type');
  let buyBtnElement = document.querySelector('div#exercise > button:last-of-type');
  let outputTextAreaElement = document.querySelector('div#exercise > textarea:last-of-type');
  let tableElement = document.querySelector('table.table tbody');

  generateBtnElement.addEventListener('click', (e) => {
    let furniture = JSON.parse(inputTextAreaElement.value);

    furniture.forEach(element => {
      let rowElement = document.createElement('tr');

      let imageColElement = document.createElement('td');
      let imageElement = document.createElement('img');
      imageElement.src = element.img;
      imageColElement.appendChild(imageElement);
      rowElement.appendChild(imageColElement);

      let nameColElement = document.createElement('td');
      let nameElement = document.createElement('p');
      nameElement.textContent = element.name;
      nameColElement.appendChild(nameElement);
      rowElement.appendChild(nameColElement);

      let priceColElement = document.createElement('td');
      let priceElement = document.createElement('p');
      priceElement.textContent = element.price;
      priceColElement.appendChild(priceElement);
      rowElement.appendChild(priceColElement);

      let decorationFactorColElement = document.createElement('td');
      let decorationFactorElement = document.createElement('p');
      decorationFactorElement.textContent = element.decFactor;
      decorationFactorColElement.appendChild(decorationFactorElement);
      rowElement.appendChild(decorationFactorColElement);

      let inputCheckboxColElement = document.createElement('td');
      let inputCheckboxElement = document.createElement('input');
      inputCheckboxElement.type = 'checkbox';
      inputCheckboxColElement.appendChild(inputCheckboxElement);
      rowElement.appendChild(inputCheckboxColElement);

      tableElement.appendChild(rowElement);
    });
  });

  buyBtnElement.addEventListener('click', (e) => {
    let checkboxElements = Array.from(document.querySelectorAll('table.table tbody input[type="checkbox"]'));
    checkboxElements = checkboxElements.filter(x => x.checked);
    let furniture = [];

    checkboxElements.forEach(element => {
      let parentRowElement = element.parentNode.parentNode;

      furniture.push({
        name: parentRowElement.querySelector('td:nth-of-type(2) p').textContent,
        price: Number(parentRowElement.querySelector('td:nth-of-type(3) p').textContent),
        decFactor: Number(parentRowElement.querySelector('td:nth-of-type(4) p').textContent)
      });
    });

    let totalPrice = Number(furniture.reduce((a, c) => a + c.price, 0)).toFixed(2);
    let averageDecorationFactor = furniture.reduce((a, c) => a + c.decFactor / furniture.length, 0);

    let output = `Bought furniture: ${furniture.map(x => x.name).join(', ')}\n`;
    output += `Total price: ${totalPrice}\n`;
    output += `Average decoration factor: ${averageDecorationFactor}`;

    outputTextAreaElement.value = output;
  });
}
