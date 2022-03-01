function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', loadPosts);
    document.getElementById('btnViewPost').addEventListener('click', viewPosts);
}

async function loadPosts(e) {
    try {
        const url = 'http://localhost:3030/jsonstore/blog/posts';
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();
        document.getElementById('posts').innerHTML = '';

        Object.entries(data).forEach(([key, value]) => {
            let optionElement = document.createElement('option');
            optionElement.value = key;
            optionElement.textContent = value.title;
            document.getElementById('posts').appendChild(optionElement);
        });
    } catch (error) {
        console.log(error);
    }
}

async function viewPosts(e) {
    try {
        const selectElement = document.getElementById('posts');
        const url = `http://localhost:3030/jsonstore/blog/comments`;

        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();
        let comments = Object.values(data).filter(x => x.postId === selectElement.value);
        document.getElementById('post-title').textContent = selectElement.selectedOptions[0].textContent;
        document.getElementById('post-comments').innerHTML = '';

        comments.forEach(element => {
            let liElement = document.createElement('li');
            liElement.textContent = element.text;
            document.getElementById('post-comments').appendChild(liElement);
        });
    } catch (error) {
        console.log(error);
    }
}

attachEvents();
