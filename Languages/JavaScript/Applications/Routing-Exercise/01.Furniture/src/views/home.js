import { showView } from '../navigation/router.js';

// Select view
const homeView = document.querySelector('div.home-view');

// Export render function
export async function renderHome() {
    showView(homeView);
}
