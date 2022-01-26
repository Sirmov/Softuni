function encodeAndDecodeMessages() {
    let buttonElements = document.querySelectorAll('main button');
    let inputTextAreaElement = document.querySelector('main div:nth-of-type(1) textarea');
    let outputTextAreaElement = document.querySelector('main div:nth-of-type(2) textarea');

    for (const element of buttonElements) {
        if (element.textContent == 'Encode and send it') {
            element.addEventListener('click', (e) => {
                let message = inputTextAreaElement.value;
                inputTextAreaElement.value = '';

                message = message
                    .split('')
                    .map(c => String.fromCharCode(c.charCodeAt(0) + 1))
                    .join('');

                outputTextAreaElement.value = message;
            });
        } else if (element.textContent === 'Decode and read it') {
            element.addEventListener('click', (e) => {
                let message = outputTextAreaElement.value;
                outputTextAreaElement.value = '';

                message = message
                    .split('')
                    .map(c => String.fromCharCode(c.charCodeAt(0) - 1))
                    .join('');

                outputTextAreaElement.value = message;
            });
        }
    }
}
