window.addEventListener('load', solve);

function solve() {
    let addButton = document.getElementById('add');
    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        let modelInput = document.getElementById('model');
        let yearInput = document.getElementById('year');
        let descriptionInput = document.getElementById('description');
        let priceInput = document.getElementById('price');

        let model = modelInput.value;
        let year = yearInput.value;
        let description = descriptionInput.value;
        let price = priceInput.value;

        if (model && description && year && price) {
            year = Number(year);
            price = Number(price);

            if (year < 0 || price < 0) {
                return;
            }

            let table = document.getElementById('furniture-list');
            let [modelRowElement, infoRowElement] = generateRow(model, year, description, price);
            table.appendChild(modelRowElement);
            table.appendChild(infoRowElement);

            modelInput.value = '';
            yearInput.value = '';
            descriptionInput.value = '';
            priceInput.value = '';
        }
    });

    function generateRow(model, year, description, price) {
        let modelRowElement = document.createElement('tr');
        modelRowElement.classList.add('info');
        modelRowElement.innerHTML = `<td>${model}</td>
        <td>${price.toFixed(2)}</td>`;

        let buttonTDElement = document.createElement('td');

        let moreBtn = document.createElement('button');
        moreBtn.textContent = 'More Info';
        moreBtn.classList.add('moreBtn');
        moreBtn.addEventListener('click', (e) => {
            let rows = Array.from(document.querySelectorAll('#furniture-list tr'));
            let index = rows.indexOf(e.currentTarget.parentElement.parentElement) + 1;
            let row = document.querySelector(`tbody tr:nth-child(${index + 1})`);

            if (e.currentTarget.textContent === 'More Info') {
                e.currentTarget.textContent = 'Less Info';
                row.style.display = 'contents';
            } else {
                e.currentTarget.textContent = 'More Info';
                row.style.display = 'none';
            }
        });

        let buyBtn = document.createElement('button');
        buyBtn.textContent = 'Buy it';
        buyBtn.classList.add('buyBtn');
        buyBtn.addEventListener('click', (e) => {
            let row = e.currentTarget.parentElement.parentElement;
            let price = Number(row.querySelector('td:nth-of-type(2)').textContent);
            row.remove();
            let totalPriceElement = document.querySelector('.total-price');
            let newPrice = (price + Number(totalPriceElement.textContent)).toFixed(2);
            totalPriceElement.textContent = newPrice;
        });

        buttonTDElement.appendChild(moreBtn);
        buttonTDElement.appendChild(buyBtn);
        modelRowElement.appendChild(buttonTDElement);

        let infoRowElement = document.createElement('tr');
        infoRowElement.classList.add('hide');
        infoRowElement.innerHTML = `<td>Year: ${year}</td>
        <td colspan="3">Description: ${description}</td>`;

        return [modelRowElement, infoRowElement];
    }
}
