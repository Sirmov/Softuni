import { showView } from "../navigation/router.js";

const loginView = document.querySelector('div.login-view');

export function renderLogin() {
    showView(loginView);
}
