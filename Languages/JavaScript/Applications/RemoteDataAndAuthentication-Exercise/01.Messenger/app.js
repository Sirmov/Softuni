function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const messagesElement = document.getElementById('messages');
    const submitBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    submitBtn.addEventListener('click', async (e) => {
        try {
            let username = document.querySelector('input[name="author"]').value;
            let content = document.querySelector('input[name="content"]').value;

            let response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ author: username, content })
            });

            if (!response.ok) {
                throw new Error();
            }
        } catch (error) {
            console.log(error);
        }
    });

    refreshBtn.addEventListener('click', async (e) => {
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();

        messagesElement.value =
            Object.values(data).map(x => `${x.author}: ${x.content}`).join('\n');
    });
}

attachEvents();
