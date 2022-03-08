export function showView(view) {
    hideAllViews();
    view.style.display = 'flex';
}

export function hideAllViews() {
    document.querySelectorAll('div.view').forEach(x => x.style.display = 'none');
}
