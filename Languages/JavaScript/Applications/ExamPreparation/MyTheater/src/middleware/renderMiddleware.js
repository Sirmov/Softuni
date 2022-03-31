// Inject dependencies into context
import { getUserEmail } from '../utils/auth.js';
import { render } from '../utils/lib.js';
import { navigationTemplate } from '../views/navigationView.js';

// Select root element
const rootElement = document.getElementById('container');
const navigationContainer = rootElement.querySelector('header#site-header');
const contentContainer = rootElement.querySelector('main#site-content');

function ctxRender(templateResult) {
    render(navigationTemplate(getUserEmail()), navigationContainer);
    return render(templateResult, contentContainer);
}

export function renderMiddleware(ctx, next) {
    ctx.render = ctxRender;

    next();
}
