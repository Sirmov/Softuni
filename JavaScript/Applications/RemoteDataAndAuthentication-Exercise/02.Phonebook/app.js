function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook';
    const phoneBookElement = document.getElementById('phonebook');
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', async (e) => {
        try {
            let response = await fetch(url);

            if (!response.ok) {
                throw new Error();
            }

            let data = await response.json();

            phoneBookElement.innerHTML = '';
            Object.values(data).forEach(element => {
                let liElement = document.createElement('li');
                liElement.textContent = `${element.person}: ${element.phone}`;
                let deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                deleteBtn.addEventListener('click', deleteOnClick);
                liElement.appendChild(deleteBtn);
                phoneBookElement.appendChild(liElement);
            });
        } catch (error) {
            console.log(error);
        }
    });

    createBtn.addEventListener('click', async (e) => {
        try {
            let personInputElement = document.getElementById('person');
            let phoneInputElement = document.getElementById('phone');
            let person = personInputElement.value;
            let phone = phoneInputElement.value;

            let response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ person, phone })
            });

            personInputElement.value = '';
            phoneInputElement.value = '';

            if (!response.ok) {
                throw new Error();
            }

            loadBtn.click();
        } catch (error) {
            console.log(error);
        }
    });
}

async function deleteOnClick(e) {
    const url = 'http://localhost:3030/jsonstore/phonebook';
    const liElement = e.currentTarget.parentElement;
    const [person, phone] = liElement
        .textContent.replace('Delete', '').split(': ');

    let response = await fetch(url);

    if (!response.ok) {
        throw new Error();
    }

    let data = await response.json();
    let id = Object.entries(data).find(x => x[1].person === person && x[1].phone === phone)[0];

    await fetch(`${url}/${id}`, {
        method: 'DELETE'
    });

    liElement.remove();
}

attachEvents();
