import { showView } from "../utils.js";
import { initPost } from "./post.js";

const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
const homeView = document.querySelector('div.container');
const topicContainer = homeView.querySelector('div.topic-container');
const formElement = homeView.querySelector('main form');
const cancelButton = formElement.querySelector('button.cancel');

export function initHome() {
    loadPosts();

    topicContainer.addEventListener('click', async (e) => {
        e.preventDefault();

        if (e.target.tagName == 'H2') {
            let response = await fetch(`${url}/${e.target.parentElement.id}`);
            let postInfo = await response.json();
            await initPost(postInfo);
        }
    });

    formElement.addEventListener('submit', async (e) => {
        e.preventDefault();

        let formData = new FormData(formElement);
        let title = formData.get('topicName');
        let username = formData.get('username');
        let post = formData.get('postText');

        if (title && username && post) {
            await postTopicRequest(title, username, post);
            loadPosts();
            formElement.reset();
            alert('Successfully created!');
        } else {
            alert('Invalid input!');
        }
    });

    cancelButton.addEventListener('click', (e) => {
        e.preventDefault();
        formElement.reset();
    });

    showView(homeView);
}

async function postTopicRequest(title, username, post) {
    try {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title, username, post, dateCreated: new Date().toISOString() })
        });

        if (response.status !== 200) {
            throw new Error();
        }

        return await response.json();
    } catch (error) {
        alert('Error creating topic!');
    }
}

async function getPostsRequest() {
    try {
        let response = await fetch(url);

        if (response.status !== 200) {
            throw new Error();
        }

        let data = await response.json();

        return data;
    } catch (error) {
        alert('Error loading topics!');
    }
}

function createPostElement(id, date, title, username) {
    let containerElement = document.createElement('div');
    containerElement.classList.add('topic-name-wrapper');
    containerElement.innerHTML =
        `<div class="topic-name">
            <a href="/post" id="${id}" class="normal">
                <h2>${title}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>${date}</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${username}</span></p>
                    </div>
                </div>
            </div>
        </div>`;
    return containerElement;
};

export async function loadPosts() {
    let posts = await getPostsRequest();

    let fragment = document.createDocumentFragment();

    Object.values(posts).forEach(element => {
        let post = createPostElement(element._id, element.dateCreated, element.title, element.username);
        fragment.appendChild(post);
    });

    topicContainer.appendChild(fragment);
}
