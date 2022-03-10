import { showView } from "../utils.js";

const postView = document.querySelector('div.post-view');
const url = 'http://localhost:3030/jsonstore/collections/myboard/comments';
const formElement = createForm();
let postId;

export async function initPost(postInfo) {
    postId = postInfo._id;
    postView.innerHTML =
        `<div class="theme-content">
            <!-- theme-title  -->
            <div class="theme-title">
                <div class="theme-name-wrapper">
                    <div class="theme-name">
                        <h2>${postInfo.title}</h2>
                    </div>
                </div>
            </div>
            <!-- comment  -->

            <div class="comment">
                <div class="header">
                <img src="./static/profile.png" alt="avatar">
                <p><span>${postInfo.username}</span> posted on <time>${postInfo.dateCreated}</time></p>
                <p class="post-content">${postInfo.post}</p>
            </div>

            <div class="comments"></div>
        </div>`;

    let commentsDiv = postView.querySelector('div.theme-content');
    await loadComments(postInfo._id);
    commentsDiv.appendChild(formElement);

    showView(postView);
}

async function loadComments(postId) {
    let postComments = await getPostComments(postId);

    let commentElements = document.createDocumentFragment();
    Object.values(postComments)
        .filter(x => x.postId === postId)
        .forEach(element => {
            let commentElement = createCommentElement(element);
            commentElements.appendChild(commentElement);
        });
    postView.querySelector('div.comments').appendChild(commentElements);
}

function createCommentElement(element) {
    let commentElement = document.createElement('div');
    commentElement.classList.add('answer-comment');
    commentElement.innerHTML =
        `<div id="user-comment">
                <div class="topic-name-wrapper">
                    <div class="topic-name">
                        <p><strong>${element.username}</strong> commented on <time>${element.dateCreated}</time></p>
                        <div class="post-content">
                            <p>${element.comment}</p>
                        </div>
                    </div>
                </div>
            </div>`;

    return commentElement;
}

async function getPostComments(postId) {
    try {
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        try {
            let comments = await response.json();
            return comments;
        } catch (e) { return {} }
    } catch (error) {
        alert('Error loading topic comments!');
    }
}

async function postCommentOnSubmit(e) {
    e.preventDefault();
    let form = e.currentTarget;
    let formData = new FormData(form);
    let username = formData.get('username');
    let comment = formData.get('postText');

    if (username && comment) {
        await postCommentRequest(username, comment, postId);
        await loadComments(postId);
        form.reset();
    } else {
        alert('Invalid input!');
    }
}

async function postCommentRequest(username, comment, postId) {
    try {
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, comment, dateCreated: new Date().toISOString(), postId })
        });

        if (!response.ok) {
            throw new Error();
        }
    } catch (error) {
        alert('Error posting comment!');
    }
}

function createForm() {
    let formElement = document.createElement('div');
    formElement.classList.add('answer-comment');
    formElement.innerHTML = `<p><span>currentUser</span> comment:</p>`;
    let divAnswer = document.createElement('div');
    divAnswer.classList.add('answer');
    let form = document.createElement('form');
    form.innerHTML = `<textarea name="postText" id="comment" cols="30" rows="10"></textarea>
    <div>
        <label for="username">Username <span class="red">*</span></label>
        <input type="text" name="username" id="username">
    </div>
    <button>Post</button>`;
    form.addEventListener('submit', postCommentOnSubmit);
    divAnswer.appendChild(form);
    formElement.appendChild(divAnswer);
    return formElement;
}
