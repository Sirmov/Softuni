const submitBtn = document.getElementById('submit');
const url = 'http://localhost:3030/jsonstore/collections/students';

submitBtn.addEventListener('click', async (e) => {
    e.preventDefault();
    let form = document.getElementById('form');
    let formData = new FormData(form);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = formData.get('grade');

    if (firstName && lastName && facultyNumber && grade) {
        grade = Number(grade);

        try {
            let response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
            });

            if (!response.ok) {
                throw new Error();
            }

            document.querySelector('p.notification').textContent = '';
            loadStudents();
        } catch (error) {
            console.log(error);
            document.querySelector('p.notification').textContent = 'Error submitting';
        }
    } else {
        document.querySelector('p.notification').textContent = 'Input should be non-empty!';
    }
});

async function loadStudents() {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        document.querySelector('table#results tbody').innerHTML = '';

        let data = await response.json();

        Object.values(data).forEach(element => {
            let rowElement = document.createElement('tr');
            rowElement.innerHTML =
                `<th>${element.firstName}</th>
            <th>${element.lastName}</th>
            <th>${element.facultyNumber}</th>
            <th>${element.grade}</th>`;
            document.querySelector('table#results tbody').appendChild(rowElement);
        });

        document.querySelector('p.notification').textContent = '';
    } catch (error) {
        console.log(error);
        document.querySelector('p.notification').textContent = 'Error loading';
    }
}
loadStudents();
