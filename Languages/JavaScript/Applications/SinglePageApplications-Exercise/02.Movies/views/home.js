import { showView } from "../navigation/router.js";

const homeView = document.querySelector('div.home-view');

export function renderHome() {
    showView(homeView);
}
