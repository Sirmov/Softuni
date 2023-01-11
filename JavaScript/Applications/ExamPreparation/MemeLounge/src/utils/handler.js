import { render, nothing, html } from './lib.js';

const notificationContainer = document.getElementById('notifications');

export function createSubmitHandler(ctx, handler, allowedData) {
    return function (event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const formEntries = [...formData.entries()];
        let data;

        if (allowedData !== undefined) {
            data = formEntries.reduce((a, [k, v]) => (allowedData.includes(k) ? Object.assign(a, { [k]: v }) : a), {});
        } else {
            data = Object.fromEntries(formData);
        }

        if (Object.values(data).some((x) => x === '')) {
            notification('Empty fields!');
            throw new Error('Empty fields!');
        } else {
            handler(ctx, data, event);
        }
    };
}

export function createEventHandler(ctx, handler) {
    return function (event) {
        event.preventDefault();
        handler(ctx, event);
    };
}

export function notification(message) {
    render(notificationTemplate(message), notificationContainer);
    setTimeout(() => render(nothing, notificationContainer), 3000);
}

const notificationTemplate = (message) =>
    html`<div id="errorBox" class="notification" style="display: block;">
        <span>${message}</span>
    </div>`;
