import { showView } from "../navigation/router.js";

const registerView = document.querySelector('div.register-view');


export function renderRegister() {
    showView(registerView);
}
