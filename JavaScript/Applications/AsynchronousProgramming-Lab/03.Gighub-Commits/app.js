function loadCommits() {
    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;
    let listElement = document.getElementById('commits');

    getCommits();

    async function getCommits() {
        try {
            let response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);

            if (!response.ok) {
                throw new Error(response.status);
            }

            let data = await response.json();
            listElement.innerHTML = '';
            data.forEach(element => {
                let liElement = document.createElement('li');
                liElement.innerHTML = `${element.commit.author.name}: ${element.commit.message}`;
                listElement.appendChild(liElement);
            });
        } catch (error) {
            listElement.innerHTML = '';
            let errorElement = document.createElement('li');
            errorElement.textContent = `Error: ${error.message} (Not Found)`;
            listElement.appendChild(errorElement);
        }
    }
}
