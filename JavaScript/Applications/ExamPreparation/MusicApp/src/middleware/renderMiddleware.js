// Inject dependencies into context
import { render } from '../utils/lib.js';
import { mainTemplate } from '../views/mainView.js';

export function renderMiddleware(ctx, next) {
    ctx.render = (templateResult) => render(mainTemplate(templateResult, ctx), ctx.rootElement);

    next();
}
