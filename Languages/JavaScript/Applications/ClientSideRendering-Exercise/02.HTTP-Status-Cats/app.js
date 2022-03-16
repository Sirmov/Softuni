import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';
import { cats } from './catSeeder.js';

const rootElement = document.getElementById('allCats');

const statusCodeTemplate = (cat) => html`
    <li>
        <img src=${`./images/${cat.imageLocation}.jpg`} width="250" height="250" alt="Card image cap" />
        <div class="info">
            <button class="showBtn" @click=${toggleStatusInfo}>Show status code</button>
            <div class="status" style="display: none" id=${cat.statusCode}>
                <h4>Status Code: ${cat.statusCode}</h4>
                <p>${cat.statusMessage}</p>
            </div>
        </div>
    </li>
`;

const statusCodesListTemplate = (cats) => html`
<ul>
    ${repeat(cats, (element) => element.statusCode, (element, index) => statusCodeTemplate(element))}
</ul>
`;

render(statusCodesListTemplate(cats), rootElement);

function toggleStatusInfo(event) {
    let buttonElement = event.currentTarget;
    let statusDiv = buttonElement.parentElement.querySelector('div.status');

    if (buttonElement.textContent === 'Show status code') {
        buttonElement.textContent = 'Hide status code';
        statusDiv.style.display = 'block';
    } else {
        buttonElement.textContent = 'Show status code';
        statusDiv.style.display = 'none';
    }
}
