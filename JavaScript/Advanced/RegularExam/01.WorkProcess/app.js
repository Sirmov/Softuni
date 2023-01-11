function solve() {
    let hireBtn = document.getElementById('add-worker');

    hireBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let firstNameInputElement = document.getElementById('fname');
        let lastNameInputElement = document.getElementById('lname');
        let emailInputElement = document.getElementById('email');
        let dateOfBirthInputElement = document.getElementById('birth');
        let positionInputElement = document.getElementById('position');
        let salaryInputElement = document.getElementById('salary');

        let firstName = firstNameInputElement.value;
        let lastName = lastNameInputElement.value;
        let email = emailInputElement.value;
        let dateOfBirth = dateOfBirthInputElement.value;
        let position = positionInputElement.value;
        let salary = salaryInputElement.value;

        if (firstName && lastName && email && dateOfBirth && position && salary) {
            salary = Number(salary);
            let rowElement = document.createElement('tr');
            rowElement.innerHTML =
                `<td>${firstName}</td>
                <td>${lastName}</td>
                <td>${email}</td>
                <td>${dateOfBirth}</td>
                <td>${position}</td>
                <td>${salary}</td>`;

            let buttonsCol = document.createElement('td');

            let firedBtn = document.createElement('button');
            firedBtn.textContent = 'Fired';
            firedBtn.classList.add('fired');
            firedBtn.addEventListener('click', (e) => {
                let rowInfo = e.currentTarget.parentElement.parentElement.querySelectorAll('td');
                rowInfo = Array.from(rowInfo).map(x => x.textContent);
                e.currentTarget.parentElement.parentElement.remove();

                updateBudget(-rowInfo[5]);
            });

            let editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.classList.add('edit');
            editBtn.addEventListener('click', (e) => {
                let rowInfo = e.currentTarget.parentElement.parentElement.querySelectorAll('td');
                rowInfo = Array.from(rowInfo).map(x => x.textContent);
                e.currentTarget.parentElement.parentElement.remove();

                firstNameInputElement.value = rowInfo[0];
                lastNameInputElement.value = rowInfo[1];
                emailInputElement.value = rowInfo[2];
                dateOfBirthInputElement.value = rowInfo[3];
                positionInputElement.value = rowInfo[4];
                salaryInputElement.value = rowInfo[5];

                updateBudget(-rowInfo[5]);
            });

            buttonsCol.appendChild(firedBtn);
            buttonsCol.appendChild(editBtn);

            updateBudget(salary);

            rowElement.appendChild(buttonsCol);
            document.getElementById('tbody').appendChild(rowElement);

            firstNameInputElement.value = '';
            lastNameInputElement.value = '';
            emailInputElement.value = '';
            dateOfBirthInputElement.value = '';
            positionInputElement.value = '';
            salaryInputElement.value = '';
        }
    });

    function updateBudget(amount) {
        let budgetElement = document.getElementById('sum');
        budgetElement.textContent = (Number(budgetElement.textContent) + Number(amount)).toFixed(2);
    }
}
solve()
