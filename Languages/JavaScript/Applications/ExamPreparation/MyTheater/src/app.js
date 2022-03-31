// Application entry point

// Import middleware
import { dependenciesMiddleware } from './middleware/dependenciesMiddleware.js';
import { renderMiddleware } from './middleware/renderMiddleware.js';

// Import dependencies
import { page, lit } from './utils/lib.js';
import * as auth from './utils/auth.js';
import { errorHandler } from './utils/handler.js';

// Import views render logic
import { loginController } from './controllers/loginController.js';
import { registerController } from './controllers/registerController.js';
import { logoutAction } from './actions/logoutAction.js';

// Central error handling
window.addEventListener('error', errorHandler);

// Register routes
page(dependenciesMiddleware({ auth }));
page(renderMiddleware);
page('/login', loginController);
page('/register', registerController);
page('/logout', logoutAction);

page.start();
