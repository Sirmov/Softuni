function validate() {
    let emailInputElement = document.getElementById('email');

    emailInputElement.addEventListener('change', (e) => {
        let email = e.currentTarget.value;

        if (!/[a-z]+@[a-z]+\.[a-z]+/g.test(email)) {
            e.currentTarget.classList.add('error');
        } else {
            e.currentTarget.classList.remove('error');
        }
    });
}
