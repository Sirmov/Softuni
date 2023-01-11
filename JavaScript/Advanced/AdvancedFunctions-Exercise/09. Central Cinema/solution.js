function solve() {
    let onScreenBtn = document.querySelector('form#add-new button');

    onScreenBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let nameInputElement = document.querySelector('div#container input[placeholder="Name"]');
        let hallInputElement = document.querySelector('div#container input[placeholder="Hall"]');
        let priceInputElement = document.querySelector('div#container input[placeholder="Ticket Price"]');

        let name = nameInputElement.value;
        let hall = hallInputElement.value;
        let price = Number(priceInputElement.value);

        if (name && hall && price) {
            let liElement = document.createElement('li');

            let spanName = document.createElement('span');
            spanName.textContent = name;
            liElement.appendChild(spanName);

            let strongHall = document.createElement('strong');
            strongHall.textContent = `Hall: ${hall}`
            liElement.appendChild(strongHall);

            let divElement = document.createElement('div');

            let strongPrice = document.createElement('strong');
            strongPrice.textContent = price.toFixed(2);
            divElement.appendChild(strongPrice);

            let inputTickets = document.createElement('input');
            inputTickets.setAttribute('placeholder', 'Tickets Sold');
            divElement.appendChild(inputTickets);

            let archiveBtn = document.createElement('button');
            archiveBtn.textContent = 'Archive';
            archiveBtn.addEventListener('click', (e) => {
                let parentElement = e.currentTarget.parentElement.parentElement;
                let soldTickets = parentElement.querySelector('input[placeholder="Tickets Sold"]').value;

                if (soldTickets == '') {
                    return;
                }

                soldTickets = Number(soldTickets);

                if (soldTickets || soldTickets === 0) {
                    let archiveLiElement = document.createElement('li');
                    let ticketPrice = Number(parentElement.querySelector('div strong').textContent);
                    archiveLiElement.appendChild(parentElement.querySelector('span').cloneNode(true));

                    let strongTotalAmount = document.createElement('strong');
                    strongTotalAmount.textContent = `Total amount: ${(soldTickets * ticketPrice).toFixed(2)}`;
                    archiveLiElement.appendChild(strongTotalAmount);

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';
                    deleteBtn.addEventListener('click', (e) => {
                        e.currentTarget.parentElement.remove();
                    });
                    archiveLiElement.appendChild(deleteBtn);

                    parentElement.remove();

                    document.querySelector('section#archive ul').appendChild(archiveLiElement);
                }
            })

            divElement.appendChild(archiveBtn);
            liElement.appendChild(divElement);
            document.querySelector('section#movies ul').appendChild(liElement);

            nameInputElement.value = '';
            hallInputElement.value = '';
            priceInputElement.value = '';
        }
    });

    let clearBtn = document.querySelector('section#archive button');
    clearBtn.addEventListener('click', (e) => {
        let liElements = e.currentTarget.parentElement.querySelectorAll('ul li');
        Array.from(liElements).forEach(element => {
            element.remove();
        })
    })
}
