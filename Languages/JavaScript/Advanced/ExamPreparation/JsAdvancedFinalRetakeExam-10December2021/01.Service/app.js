window.addEventListener('load', solve);

function solve() {
    let submitBtn = document.querySelector('button[type="submit"]');

    submitBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let typeInputElement = document.getElementById('type-product');
        let descriptionInputElement = document.getElementById('description');
        let clientNameInputElement = document.getElementById('client-name');
        let clientPhoneInputElement = document.getElementById('client-phone');

        let type = typeInputElement.value;
        let description = descriptionInputElement.value;
        let clientName = clientNameInputElement.value;
        let clientPhone = clientPhoneInputElement.value;

        if (description && clientName && clientPhone) {
            let divElement = document.createElement('div');
            divElement.classList.add('container');
            divElement.innerHTML =
                `<h2>Product type for repair: ${type}</h2>
                <h3>Client information: ${clientName}, ${clientPhone}</h3>
                <h4>Description of the problem: ${description}</h4>`;

            let startBtn = document.createElement('button');
            startBtn.classList.add('start-btn');
            startBtn.textContent = 'Start repair';

            startBtn.addEventListener('click', (e) => {
                e.currentTarget.disabled = true;
                finishBtn.disabled = false;
            });

            let finishBtn = document.createElement('button');
            finishBtn.classList.add('finish-btn');
            finishBtn.textContent = 'Finish repair';
            finishBtn.disabled = true;

            finishBtn.addEventListener('click', (e) => {
                let divElement = e.currentTarget.parentElement;
                Array.from(divElement.querySelectorAll('button')).forEach(x => x.remove());
                document.getElementById('completed-orders').appendChild(divElement);
            });

            divElement.appendChild(startBtn);
            divElement.appendChild(finishBtn);
            document.getElementById('received-orders').appendChild(divElement);

            typeInputElement.value = '';
            descriptionInputElement.value = '';
            clientNameInputElement.value = '';
            clientPhoneInputElement.value = '';
        }
    });

    let clearBtn = document.querySelector('.clear-btn');

    clearBtn.addEventListener('click', (e) => {
    Array.from(e.currentTarget.parentElement.querySelectorAll('div.container')).forEach(x => x.remove());
    });
}
