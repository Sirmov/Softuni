// Inject dependencies into context
import { render } from '../utils/lib.js';
import { mainTemplate } from '../views/mainView.js';

// Select root element
const rootElement = document.body;

function ctxRender(templateResult) {
    return render(mainTemplate(templateResult, rootElement));
}

export function renderMiddleware(ctx, next) {
    ctx.render = ctxRender;

    next();
}
