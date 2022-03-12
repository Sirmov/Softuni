import { getMovie, getMovieLikes } from "../api/request.js";
import { showView } from "../navigation/router.js";

const movieView = document.querySelector('div.movie-view');

export async function renderMovie(movieId) {
    let movie = await getMovie(movieId);
    let movieElement = await createMovieElement(movie);
    movieView.replaceChildren(movieElement);
    showView(movieView);
}

async function createMovieElement(movie) {
    let section = document.createElement('section');
    section.id = 'movie-example';
    section.innerHTML = `
    <div class="container">
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movie.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail"
                    src="${movie.img}" alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${movie.description}</p>
                <a class="btn btn-danger" href="#">Delete</a>
                <a class="btn btn-warning" href="#">Edit</a>
                <a class="btn btn-primary" href="#">Like</a>
                <span class="enrolled-span">Liked ${await getMovieLikes(movie._id)}</span>
            </div>
        </div>
    </div>
    `;
    return section;
}
