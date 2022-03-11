// Page navigation module

const viewContainer = document.querySelector('#views');
const router = { route, showView };
let links, views;

export function initialize(linksDI, viewsDI) {
    links = linksDI;
    views = viewsDI;
    return router;
}

export function route(path, ...params) {
    const view = links[path];
    const renderer = views[view];
    if (typeof renderer === 'function') {
        renderer(...params);
    }
}

export function showView(view) {
    viewContainer.replaceChildren(view);
}
