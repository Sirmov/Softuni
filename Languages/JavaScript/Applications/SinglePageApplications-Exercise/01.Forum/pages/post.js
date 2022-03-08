import { showView } from "../utils.js";

const postView = document.querySelector('div.post-view');

export function initPost(postInfo) {
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

            <div class="answer-comment">
                <p><span>currentUser</span> comment:</p>
                <div class="answer">
                    <form>
                        <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
                        <div>
                            <label for="username">Username <span class="red">*</span></label>
                            <input type="text" name="username" id="username">
                        </div>
                        <button>Post</button>
                    </form>
                </div>
            </div>

        </div>`;

    showView(postView);
}
