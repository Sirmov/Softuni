import { getAccessToken, getUserId } from "../auth.js";

const homeView = document.getElementById('home-view');
const catchesDiv = homeView.querySelector('div#catches');
const loadBtn = homeView.querySelector('aside button.load');
const addBtn = homeView.querySelector('aside button.add');
const addForm = homeView.querySelector('#addForm');
const dataURL = 'http://localhost:3030/data/catches';

addBtn.addEventListener('click', async (e) => {
    e.preventDefault();

    let formData = new FormData(addForm);
    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');

    if (angler && weight && species && location && bait && captureTime) {
        try {
            let response = await fetch(dataURL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': getAccessToken()
                },
                body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
            });

            if (!response.ok) {
                throw new Error();
            }
        } catch (error) {
            alert('Error adding!');
        }

        loadCatches();
        alert('Successfully added!');
    } else {
        alert('Invalid input!');
    }
});

loadBtn.addEventListener('click', async (e) => {
    e.preventDefault();

    try {
        let response = await fetch(dataURL);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();
        let catchesFragment = document.createDocumentFragment();

        data.forEach(element => {
            let isOwn = getUserId() === element._ownerId;

            let divElement = document.createElement('div');
            divElement.classList.add('catch');
            divElement.innerHTML =
                `<label>Angler</label>
               <input type="text" class="angler" value="${element.angler}" ${isOwn ? '' : 'disabled'}>
               <label>Weight</label>
               <input type="text" class="weight" value="${element.weight}" ${isOwn ? '' : 'disabled'}>
               <label>Species</label>
               <input type="text" class="species" value="${element.species}" ${isOwn ? '' : 'disabled'}>
               <label>Location</label>
               <input type="text" class="location" value="${element.location}" ${isOwn ? '' : 'disabled'}>
               <label>Bait</label>
               <input type="text" class="bait" value="${element.bait}" ${isOwn ? '' : 'disabled'}>
               <label>Capture Time</label>
               <input type="number" class="captureTime" value="${element.captureTime}" ${isOwn ? '' : 'disabled'}>`;

            let updateBtn = document.createElement('button');
            updateBtn.classList.add('update');
            updateBtn.dataset.id = element._id;
            updateBtn.textContent = 'Update';
            updateBtn.addEventListener('click', updateOnClick);

            let deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete');
            deleteBtn.dataset.id = element._id;
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteOnClick);

            if (!isOwn) {
                updateBtn.disabled = true;
                deleteBtn.disabled = true;
            }

            divElement.appendChild(updateBtn);
            divElement.appendChild(deleteBtn);

            catchesFragment.appendChild(divElement);
        });

        catchesDiv.replaceChildren(catchesFragment);
    } catch (error) {
        alert('Error loading!');
    }
});

async function updateOnClick(e) {
    let catchID = e.currentTarget.dataset.id;
    let formData = new FormData(addForm);
    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');

    if (angler && weight && location && bait && captureTime) {
        try {
            let response = await fetch(`${dataURL}/${catchID}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': getAccessToken()
                },
                body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
            });

            if (!response.ok) {
                throw new Error();
            }
        } catch (error) {
            alert('Error updating!');
        }

        loadCatches();
        alert('Successfully updated!');
    } else {
        alert('Invalid input!');
    }
}

async function deleteOnClick(e) {
    let catchID = e.currentTarget.dataset.id;

    try {
        let response = await fetch(`${dataURL}/${catchID}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': getAccessToken()
            }
        });

        if (!response.ok) {
            throw new Error();
        }
    } catch (error) {
        alert('Error deleting!');
    }

    loadCatches();
    alert('Successfully deleted!');
}

export function renderHome() {
    homeView.style.display = 'inline-block';
}

export function loadCatches() {
    loadBtn.click();
}
