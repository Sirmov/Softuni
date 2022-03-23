import { editTemplate } from '../views/editView.js';

export function editController(ctx, next) {
    ctx.render(editTemplate());
}
