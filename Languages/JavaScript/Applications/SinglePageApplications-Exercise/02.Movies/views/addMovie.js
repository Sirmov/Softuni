import { postMovie } from "../api/request.js";
import { getAccessToken } from "../auth/authentication.js";
import { route, showView } from "../navigation/router.js";

const addMovieView = document.querySelector('div.addMovie-view');
const formElement = addMovieView.querySelector('form');
formElement.addEventListener('submit', addMovie);

export function renderAddMovie() {
    showView(addMovieView);
}

async function addMovie(event) {
    event.preventDefault();

    let formData = new FormData(formElement);
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    if (title && description && img) {
        try {
            await postMovie({ title, description, img, _ownerId: getAccessToken() });
            alert('Successfully added a movie!');
            route('/');
        } catch (error) {
            formElement.reset();
        }
    } else {
        alert('Invalid input!');
        formElement.reset();
    }
}
