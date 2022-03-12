import { route, showView } from "../navigation/router.js";
import { getUserData } from "../auth/authentication.js"
import { getAllMovies } from "../api/request.js";

const homeView = document.querySelector('div.home-view');
const moviesSection = homeView.querySelector('section#movie div.card-deck');
const addMovieSection = homeView.querySelector('section#add-movie-button');
const addMovieBtn = addMovieSection.querySelector('a.btn');
addMovieBtn.addEventListener('click', addMovieOnClick);

export async function renderHome() {
    updateAddMovieBtn();
    await renderMovies();
    showView(homeView);
}

async function renderMovies() {
    let movies = await getAllMovies();
    let moviesFragment = document.createDocumentFragment();
    movies.forEach(movie => {
        let movieElement = createMovieElement(movie);
        moviesFragment.appendChild(movieElement);
    });
    moviesSection.replaceChildren(moviesFragment);
}

function createMovieElement(movie) {
    let divElement = document.createElement('div');
    divElement.classList.add('card', 'mb-4');
    divElement.dataset.id = movie._id;
    divElement.dataset.ownerId = movie._ownerId;
    divElement.innerHTML = `
        <img class="card-img-top" src="${movie.img}"
            alt="Card image cap" width="400">
        <div class="card-body">
            <h4 class="card-title">${movie.title}</h4>
        </div>
        <div class="card-footer">
            <a href="/movie">
                <button type="button" class="btn btn-info">Details</button>
            </a>
        </div>
    `;
    return divElement;
}

function updateAddMovieBtn() {
    const userData = getUserData();

    if (userData) {
        addMovieSection.replaceChildren(addMovieBtn);
    } else {
        addMovieSection.replaceChildren();
    }
}

function addMovieOnClick(event) {
    event.preventDefault();
    route('/addMovie');
}
