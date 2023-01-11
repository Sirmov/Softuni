import { getIdea, deleteIdea } from '../api/request.js';
import { getUserId } from '../auth/authentication.js';
import { route, showView } from '../navigation/router.js';

const ideaView = document.querySelector('div.idea-view');

export async function renderIdea(ideaId) {
    let idea = await getIdea(ideaId);
    let ideaElement = createIdeaElement(idea);
    ideaView.replaceChildren(ideaElement);
    showView(ideaView);
}

async function deleteOnClick(event) {
    event.preventDefault();
    let idea = event.currentTarget.parentElement.parentElement;
    console.log(idea);
    await deleteIdea(idea.dataset.id);
    alert('Successfully deleted idea!');
    await route('/dashboard');
}

function createIdeaElement(idea) {
    let isOwner = getUserId() === idea._ownerId;

    let div = document.createElement('div');
    div.classList.add('container', 'home', 'some');
    div.dataset.id = idea._id;
    div.innerHTML = `
    <img class="det-img" src="${idea.img}" />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>
    ${
        isOwner
            ? `<div class="text-center">
                    <a class="btn detb" href="">Delete</a>
                </div>`
            : ``
    }
    `;

    if (isOwner) {
        let deleteBtn = div.querySelector('a.btn.detb');
        deleteBtn.addEventListener('click', deleteOnClick);
    }
    return div;
}
