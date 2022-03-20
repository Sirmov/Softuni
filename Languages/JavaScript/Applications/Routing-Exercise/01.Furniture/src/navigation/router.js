// Page navigation module

// Select root container
const viewContainer = document.querySelector('#views');
const router = { route, showView };
let links, views;

// Inject dependencies
export function initialize(linksDI, viewsDI) {
    links = linksDI;
    views = viewsDI;
    return router;
}

// Route via link
export async function route(path, ...params) {
    const view = links[path];
    const renderer = views[view];
    if (typeof renderer === 'function') {
        await renderer(...params);
    }
}

// Show view
export function showView(view) {
    viewContainer.replaceChildren(view);
}
