function toggle() {
    let buttonElement = document.querySelector('span.button');
    let infoElement = document.getElementById('extra');
    let isOn = buttonElement.textContent === 'More';

    if (isOn) {
        buttonElement.textContent = 'Less';
        infoElement.style.display = 'block';
    } else {
        buttonElement.textContent = 'More';
        infoElement.style.display = 'none';
    }
}
