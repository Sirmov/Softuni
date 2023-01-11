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
import { registerController } from './controllers/registerController.js';
import { logoutController } from './controllers/logoutController.js';
import { catalogController } from './controllers/catalogController.js';
import { createController } from './controllers/createController.js';
import { detailsController } from './controllers/detailsController.js';
import { editController } from './controllers/editController.js';
import { searchController } from './controllers/searchController.js';
import { deleteController } from './controllers/deleteController.js';

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
page('/create', createController);
page('/details/:id', detailsController);
page('/edit/:id', editController);
page('/delete/:id', deleteController);
page('/search', searchController);

page.start();
