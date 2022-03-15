import { getIdeas } from '../api/request.js';
import { route, showView } from '../navigation/router.js';

const dashboardView = document.querySelector('div.dashboard-view');
dashboardView.addEventListener('click', navigate);

export async function renderDashboard() {
    let ideas = await getIdeas();

    if (ideas.length === 0) {
        let message = document.createElement('h1');
        message.textContent = 'No ideas yet! Be the first one :)';
        dashboardView.replaceChildren(message);
    } else {
        let ideasFragment = document.createDocumentFragment();
        ideas.forEach((idea) => {
            let ideaElement = createIdeaElement(idea);
            ideasFragment.appendChild(ideaElement);
        });
        dashboardView.replaceChildren(ideasFragment);
    }

    showView(dashboardView);
}

function createIdeaElement(idea) {
    let div = document.createElement('div');
    div.classList.add('card', 'overflow-hidden', 'current-card', 'details');
    div.dataset.id = idea._id;
    div.style.width = '20rem';
    div.style.height = '18rem';
    div.innerHTML = `
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a class="btn" href="/idea">Details</a>
    `;
    return div;
}

async function navigate(event) {
    event.preventDefault();
    const ideaElement = event.target.parentElement;

    if (event.target.tagName === 'A' && event.target.href) {
        const url = new URL(event.target.href);

        await route(url.pathname, ideaElement.dataset.id);
    }
}
