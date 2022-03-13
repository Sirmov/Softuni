import { getMovie, putMovie } from "../api/request.js";
import { getUserId } from "../auth/authentication.js";
import { route, showView } from "../navigation/router.js";

const editMovieView = document.querySelector('div.editMovie-view');
const formElement = editMovieView.querySelector('form');

export async function renderEditMovie(movieId) {
    let movie = await getMovie(movieId);
    attachEventListener(movieId);
    populateInput(movie);
    showView(editMovieView);
}

function populateInput(movie) {
    const titleInput = formElement.querySelector('input#title');
    const descriptionInput = formElement.querySelector('textarea[name="description"]');
    const imgInput = formElement.querySelector('input#imageUrl');

    titleInput.value = movie.title;
    descriptionInput.value = movie.description;
    imgInput.value = movie.img;
}

function attachEventListener(movieId) {
    if (!formElement.dataset.listener) {
        formElement.addEventListener('submit', editMovie.bind(null, movieId));
        formElement.dataset.listener = 'true';
    }
}

async function editMovie(movieId, event) {
    event.preventDefault();

    let formData = new FormData(formElement);
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    if (title && description && img) {
        await putMovie(movieId, { title, description, img, _ownerId: getUserId() });
        alert('Successfully edited!');
        route('/movie', movieId);
    } else {
        alert('Invalid input!');
    }
}
