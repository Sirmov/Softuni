// Application entry point

// Import middleware
import { dependenciesMiddleware } from './middleware/dependenciesMiddleware.js';
import { renderMiddleware } from './middleware/renderMiddleware.js';

// Import dependencies
import { page, lit } from './utils/lib.js';
import * as auth from './utils/auth.js';

// Import views render logic
import { loginController } from './controllers/loginController.js';
import { registerController } from './controllers/registerController.js';
import { logoutController } from './controllers/logoutController.js';

// Register routes
page(dependenciesMiddleware({ auth }));
page(renderMiddleware);
page('/login', loginController);
page('/register', registerController);

page.start();
