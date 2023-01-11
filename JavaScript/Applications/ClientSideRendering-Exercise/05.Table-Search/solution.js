import { render, html } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

const url = 'http://localhost:3030/jsonstore/advanced/table';

const studentRowTemplate = (student) =>
    html`<tr>
        <td>${student.firstName} ${student.lastNamme}</td>
        <td>${student.email}</td>
        <td>${student.course}</td>
    </tr>`;
const tableTemplate = (students) =>
    html`<table class="container">
        <thead>
            <tr>
                <th>Student name</th>
                <th>Student email</th>
                <th>Student course</th>
            </tr>
        </thead>

        <tbody>
            ${repeat(
                students,
                (student) => student._id,
                (student, index) => studentRowTemplate(student)
            )}
        </tbody>

        <tfoot>
            <tr>
                <td colspan="3">
                    <input type="text" id="searchField" />
                    <button type="button" id="searchBtn" @click=${onClick}>Search</button>
                </td>
            </tr>
        </tfoot>
    </table>`;

renderTable();

function onClick(event) {
    const searchBoxElement = event.currentTarget.parentElement.querySelector('input#searchField');
    let search = searchBoxElement.value.toLowerCase();
    searchBoxElement.value = '';

    let tableRowElements = Array.from(document.querySelectorAll('tbody > tr'));
    tableRowElements.forEach((x) => x.classList.remove('select'));
    tableRowElements.forEach((element) => {
        let rowData = Array.from(element.children);
        if (rowData.some((x) => x.textContent.toLowerCase().includes(search))) {
            element.classList.add('select');
        }
    });
}

async function renderTable() {
    let students = await getStudents();
    students = Object.values(students);
    render(tableTemplate(students), document.body);
}

async function getStudents() {
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
