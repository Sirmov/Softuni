// Attach render function to context
import { logoutAction } from '../actions/logoutAction.js';
import { isLogged } from '../utils/auth.js';
import { createEventHandler } from '../utils/handler.js';
import { render } from '../utils/lib.js';
import { navigationTemplate } from '../views/navigationView.js';

// Select root element
const rootElement = document.getElementById('container');
const navigationContainer = rootElement.querySelector('header');
const contentContainer = rootElement.querySelector('main#content');

function ctxRender(ctx) {
    return function (templateResult) {
        render(navigationTemplate(isLogged(), createEventHandler(ctx, logoutAction)), navigationContainer);
        return render(templateResult, contentContainer);
    };
}

export function renderMiddleware(ctx, next) {
    ctx.render = ctxRender(ctx);

    next();
}
