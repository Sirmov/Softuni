import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';
import { towns } from './towns.js';

const townsContainer = document.getElementById('towns');
const searchInputElement = document.getElementById('searchText');
const searchButton = document.querySelector('button');
const resultContainer = document.getElementById('result');
searchButton.addEventListener('click', search);

const townsListTemplate = (towns) => html`
    <ul>
        ${repeat(towns, (element, index) => html`<li>${element}</li>`)}
    </ul>
`;

render(townsListTemplate(towns), townsContainer);

function search(event) {
    let search = searchInputElement.value.toLowerCase();
    let townElements = Array.from(townsContainer.querySelectorAll('li'));

    if (!search) {
        townElements.forEach((element) => element.classList.remove('active'));
        resultContainer.textContent = '0 matches found';
    } else {
        let count = 0;
        townElements.forEach((element) => {
            if (element.textContent.toLowerCase().includes(search)) {
                element.classList.add('active');
                count++;
            } else {
                element.classList.remove('active');
            }
        });
        resultContainer.textContent = `${count} matches found`;
    }
}
