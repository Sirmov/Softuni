// Application entry point

// Import middleware
import { renderMiddleware } from './middleware/renderMiddleware.js';

// Import dependencies
import { page } from './utils/lib.js';

// Import views render logic
import { loginController } from './controllers/loginController.js';
import { registerController } from './controllers/registerController.js';
import { homeController } from './controllers/homeController.js';
import { createController } from './controllers/createController.js';
import { detailsController } from './controllers/detailsController.js';
import { editController } from './controllers/editController.js';
import { profileController } from './controllers/profileController.js';

// Register routes
page(renderMiddleware);
page('/login', loginController);
page('/register', registerController);
page('/', homeController);
page('/create', createController);
page('/details/:id', detailsController);
page('/edit/:id', editController);
page('/profile', profileController);

page.start();
