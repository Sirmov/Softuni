window.addEventListener('load', solve);

function solve() {
    let addButton = document.getElementById('add-btn');
    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        let genreInputElement = document.getElementById('genre');
        let nameInputElement = document.getElementById('name');
        let authorInputElement = document.getElementById('author');
        let dateInputElement = document.getElementById('date');

        let genre = genreInputElement.value;
        let name = nameInputElement.value;
        let author = authorInputElement.value;
        let date = dateInputElement.value;

        if (genre && name && author && date) {
            let divElement = document.createElement('div');
            divElement.classList.add('hits-info');
            divElement.innerHTML = `<img src="./static/img/img.png">
            <h2>Genre: ${genre}</h2>
            <h2>Name: ${name}</h2>
            <h2>Author: ${author}</h2>
            <h3>Date: ${date}</h3>`;

            let saveBtn = document.createElement('button');
            saveBtn.classList.add('save-btn');
            saveBtn.textContent = 'Save song';
            saveBtn.addEventListener('click', (e) => {
                divElement.querySelector('.save-btn').remove();
                divElement.querySelector('.like-btn').remove();
                document.querySelector('.saved-container').appendChild(divElement);
            });

            let likeBtn = document.createElement('button');
            likeBtn.classList.add('like-btn');
            likeBtn.textContent = 'Like song';
            likeBtn.addEventListener('click', (e) => {
                e.currentTarget.disabled = true;
                let element = document.querySelector('#total-likes p');
                let likes = element.textContent.match(/[0-9]+/);
                likes = Number(likes[0]);
                element.textContent = `Total Likes: ${likes + 1}`;
            });

            let deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete-btn');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', (e) => {
                e.currentTarget.parentElement.remove();
            });

            divElement.appendChild(saveBtn);
            divElement.appendChild(likeBtn);
            divElement.appendChild(deleteBtn);
            document.querySelector('.all-hits-container').appendChild(divElement);

            genreInputElement.value = '';
            nameInputElement.value = '';
            authorInputElement.value = '';
            dateInputElement.value = '';
        }
    });
}
