import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const dropdownMenu = document.querySelector('div');
const formElement = document.querySelector('form');
const optionInput = formElement.querySelector('#itemText');
formElement.addEventListener('submit', addOption);

const optionTemplate = (option) => html`<option value=${option._id}>${option.text}</option>`;
const dropdownMenuTemplate = (options) => html`
    <select id="menu">
        ${repeat(
            options,
            (option) => option._id,
            (option, index) => optionTemplate(option)
        )}
    </select>
`;

await renderOptions();

async function renderOptions() {
    let options = await getAllOptions();
    render(dropdownMenuTemplate(Object.values(options)), dropdownMenu);
}

async function addOption(event) {
    event.preventDefault();

    let option = optionInput.value;

    if (option) {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ text: option })
        });

        if (!response.ok) {
            let body = await response.json();
            throw new Error(body.message);
        }

        optionInput.value = '';
        alert('Successfully created!');
        await renderOptions();
    } else {
        alert('Empty input!');
    }
}

async function getAllOptions() {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            let body = await response.json();
            throw new Error(body.message);
        }

        return response.json();
    } catch (error) {
        alert(error.message);
    }
}
