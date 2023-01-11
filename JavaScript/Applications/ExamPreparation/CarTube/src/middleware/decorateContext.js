// Inject dependencies into context
import { mainTemplate } from '../views/mainView.js';

export function decorateContext(dependencies) {
    return function (ctx, next) {
        Object.assign(ctx, dependencies);
        ctx.render = (templateResult) => ctx.lit.render(mainTemplate(templateResult, ctx), ctx.rootElement);

        next();
    };
}
