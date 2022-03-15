import { postIdea } from '../api/request.js';
import { route, showView } from '../navigation/router.js';

// Select view
const createView = document.querySelector('div.create-view');
const form = createView.querySelector('form');
form.addEventListener('submit', createSubmit);

// Export render function
export async function renderCreate() {
    showView(createView);
}

async function createSubmit(event) {
    event.preventDefault();

    let formData = new FormData(form);
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageURL');
    let errorMessages = [];

    if (title.length < 6) {
        errorMessages.push('The title should be at least 6 characters long');
    }
    if (description.length < 10) {
        errorMessages.push('The description should be at least 10 characters long.');
    }
    if (img.length < 5) {
        errorMessages.push('The image url should be at least 5 characters long.');
    }

    if (errorMessages.length === 0) {
        try {
            await postIdea({ title, description, img });
            alert('Successfully created idea!');
            form.reset();
            await route('/dashboard');
        } catch (error) {
            form.reset();
        }
    } else {
        alert(errorMessages.join(' '));
        form.reset();
    }
}
