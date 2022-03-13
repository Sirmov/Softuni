import { delMovie, getMovie, getMovieLikes, getUserLike, postLike } from "../api/request.js";
import { getUserId } from "../auth/authentication.js";
import { route, showView } from "../navigation/router.js";

const movieView = document.querySelector('div.movie-view');
let buttonsContainer, ownerBtns, userBtns, editBtn, deleteBtn, likeBtn;

export async function renderMovie(movieId) {
    let movie = await getMovie(movieId);
    let movieElement = await createMovieElement(movie);
    movieView.replaceChildren(movieElement);
    selectButtons();
    await updateButtons(movie);
    showView(movieView);
}

function selectButtons() {
    buttonsContainer = movieView.querySelector('span.buttons');
    ownerBtns = buttonsContainer.querySelector('span.owner');
    userBtns = buttonsContainer.querySelector('span.user');
    editBtn = ownerBtns.querySelector('a.btn.btn-warning');
    deleteBtn = ownerBtns.querySelector('a.btn.btn-danger');
    likeBtn = userBtns.querySelector('a.btn.btn-primary');

    if (!editBtn.dataset.listener) {
        editBtn.addEventListener('click', editMovie);
        editBtn.dataset.listener = 'true';
    }

    if (!likeBtn.dataset.listener) {
        likeBtn.addEventListener('click', likeMovie);
        likeBtn.dataset.listener = 'true';
    }

    if (!deleteBtn.dataset.listener) {
        deleteBtn.addEventListener('click', deleteMovie);
        deleteBtn.dataset.listener = 'true';
    }
}

function editMovie(event) {
    event.preventDefault();
    let movieElement = event.currentTarget.parentElement.parentElement.parentElement.parentElement.parentElement;
    route('/editMovie', movieElement.dataset.id);
}

async function likeMovie(event) {
    event.preventDefault();
    let movieElement = event.currentTarget.parentElement.parentElement.parentElement.parentElement.parentElement;
    await postLike(movieElement.dataset.id);
    alert('Successfully liked!');
    await renderMovie(movieElement.dataset.id);
}

async function deleteMovie(event) {
    event.preventDefault();
    let movieElement = event.currentTarget.parentElement.parentElement.parentElement.parentElement.parentElement;
    await delMovie(movieElement.dataset.id);
    alert('Successfully deleted!');
    route('/');
}

async function updateButtons(movie) {
    let userId = getUserId();

    if (userId && userId === movie._ownerId) {
        buttonsContainer.replaceChildren(ownerBtns);
    } else {
        let userLikes = await getUserLike(movie._id, userId);

        if (userLikes.length === 0) {
            buttonsContainer.replaceChildren(userBtns);
        } else {
            buttonsContainer.replaceChildren();
        }
    }
}

async function createMovieElement(movie) {
    let section = document.createElement('section');
    section.id = 'movie-example';
    section.innerHTML = `
    <div class="container" data-id="${movie._id}">
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movie.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail"
                    src="${movie.img}" alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${movie.description}</p>
                <span class="buttons">
                    <span class="owner">
                        <a class="btn btn-danger" href="#">Delete</a>
                        <a class="btn btn-warning" href="#">Edit</a>
                    </span>
                    <span class="user">
                        <a class="btn btn-primary" href="#">Like</a>
                    </span>
                </span>
                <span class="enrolled-span">Liked ${await getMovieLikes(movie._id)}</span>
            </div>
        </div>
    </div>
    `;
    return section;
}
