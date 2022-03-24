// Application entry point

// Import middleware
import { dependenciesMiddleware } from './middleware/dependenciesMiddleware.js';
import { renderMiddleware } from './middleware/renderMiddleware.js';

// Import dependencies
import { page, lit } from './utils/lib.js';
import * as auth from './utils/auth.js';

// Import views render logic
import { homeController } from './controllers/homeController.js';
import { loginController } from './controllers/loginController.js';
import { logoutController } from './controllers/logoutController.js';
import { registerController } from './controllers/registerController.js';
import { catalogController } from './controllers/catalogController.js';

// Select containers
const rootElement = document.body;

// Register routes
page(dependenciesMiddleware({ auth, rootElement }));
page(renderMiddleware);
page('/', homeController);
page('/login', loginController);
page('/register', registerController);
page('/logout', logoutController);
page('/catalog', catalogController);

page.start();
