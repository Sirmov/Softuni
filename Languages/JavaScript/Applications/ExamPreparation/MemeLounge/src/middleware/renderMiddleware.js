// Attach render function to context
import { logoutAction } from '../actions/logoutAction.js';
import { getUserEmail } from '../utils/auth.js';
import { createEventHandler } from '../utils/handler.js';
import { render } from '../utils/lib.js';
import { navigationTemplate } from '../views/navigationView.js';

// Select root element
const rootElement = document.getElementById('container');
const navigationContainer = rootElement.querySelector('nav');
const contentContainer = rootElement.querySelector('main');

function ctxRender(ctx) {
    return function (templateResult) {
        render(navigationTemplate(getUserEmail(), createEventHandler(ctx, logoutAction)), navigationContainer);
        return render(templateResult, contentContainer);
    };
}

export function renderMiddleware(ctx, next) {
    ctx.render = ctxRender(ctx);

    next();
}
