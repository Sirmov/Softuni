export function showView(view) {
    hideAllViews();
    view.style.display = 'flex';

    if (view.classList.value.includes('post-view')) {
        view.style.display = 'block';
    }
}

export function hideAllViews() {
    document.querySelectorAll('div.view').forEach(x => x.style.display = 'none');
}
