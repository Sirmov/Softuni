function validate() {
    let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
    let emailRegex = /^.*@.*\..*$/;
    let passwordRegex = /^[a-zA-Z0-9_]{5,15}$/;
    let isCompany = false;

    let companyCheckboxElement = document.getElementById('company');
    companyCheckboxElement.addEventListener('change', (e) => {
        isCompany = e.currentTarget.checked;
        let companyInfoElement = document.getElementById('companyInfo');

        if (isCompany) {
            companyInfoElement.style.display = 'block';
        } else {
            companyInfoElement.style.display = 'none';
        }
    });

    let submitBtnElement = document.getElementById('submit');
    submitBtnElement.addEventListener('click', (e) => {
        e.preventDefault();
        let isValid = true;

        let usernameInput = document.getElementById('username');
        let emailInput = document.getElementById('email');
        let passwordInput = document.getElementById('password');
        let passwordConfirmInput = document.getElementById('confirm-password');
        let companyNumberInput = document.getElementById('companyNumber');

        if (!usernameRegex.test(usernameInput.value)) {
            usernameInput.style.border = '2px inset red';
            isValid = false;
        } else {
            usernameInput.style.border = 'none';
        }

        if (!emailRegex.test(emailInput.value)) {
            emailInput.style.border = '2px inset red';
            isValid = false;
        } else {
            emailInput.style.border = 'none';
        }

        if (passwordConfirmInput.value !== passwordInput.value ||
            !passwordRegex.test(passwordConfirmInput.value) ||
            !passwordRegex.test(passwordInput.value)) {
            passwordConfirmInput.style.border = '2px inset red';
            passwordInput.style.border = '2px inset red';
            isValid = false;
        } else {
            passwordConfirmInput.style.border = 'none';
            passwordInput.style.border = 'none';

        }

        if (isCompany) {
            let companyNumber = Number(companyNumberInput.value);

            if (companyNumber < 1000 || companyNumber > 9999) {
                companyNumberInput.style.border = '2px inset red';
                isValid = false;
            } else {
                companyNumberInput.style.border = 'none';
            }
        }

        let validDiv = document.getElementById('valid');

        if (isValid) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }
    });
}
