import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

const rootElement = document.getElementById('root');
const formElement = document.querySelector('form');
formElement.addEventListener('submit', onLoad);

const townsListTemplate = (towns) => html`
<ul>
    ${repeat(towns, (element, index) => html`<li>${element}</li>`)}
</ul>
`;

function onLoad(event) {
    event.preventDefault();

    let formData = new FormData(formElement);
    let towns = formData.get('towns');
    towns = towns.split(', ');
    render(townsListTemplate(towns), rootElement);
}
