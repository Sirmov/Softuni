window.addEventListener('load', solution);

function solution() {
  let submitBtn = document.getElementById('submitBTN');
  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');

  submitBtn.addEventListener('click', (e) => {
    e.preventDefault();
    let fullNameInputElement = document.getElementById('fname');
    let emailInputElement = document.getElementById('email');
    let phoneNumberInputElement = document.getElementById('phone');
    let addressInputElement = document.getElementById('address');
    let postalCodeInputElement = document.getElementById('code');

    let fullName = fullNameInputElement.value;
    let email = emailInputElement.value;
    let phoneNumber = phoneNumberInputElement.value;
    let address = addressInputElement.value;
    let postalCode = postalCodeInputElement.value;

    if (fullName && email) {
      document.getElementById('infoPreview').innerHTML = `<li>Full Name: ${fullName}</li>
      <li>Email: ${email}</li>
      <li>Phone Number: ${phoneNumber}</li>
      <li>Address: ${address}</li>
      <li>Postal Code: ${postalCode}</li>`;

      fullNameInputElement.value = '';
      emailInputElement.value = '';
      phoneNumberInputElement.value = '';
      addressInputElement.value = '';
      postalCodeInputElement.value = '';

      submitBtn.disabled = true;
      editBtn.disabled = false;
      continueBtn.disabled = false;
    }

    editBtn.addEventListener('click', (e) => {
      fullNameInputElement.value = fullName;
      emailInputElement.value = email;
      phoneNumberInputElement.value = phoneNumber;
      addressInputElement.value = address;
      postalCodeInputElement.value = postalCode;

      submitBtn.disabled = false;
      editBtn.disabled = true;
      continueBtn.disabled = true;

      let liElements = Array.from(document.querySelectorAll('#infoPreview li'));
      liElements.forEach(x => x.remove());
    });
  });

  continueBtn.addEventListener('click', (e) => {
    document.getElementById('block').innerHTML = '<h3>Thank you for your reservation!</h3>';
  });
}
