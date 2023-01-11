// Application entry point

// Import middleware
import { decorateContext } from './middleware/decorateContext.js';

// Import dependencies
import { page } from './lib.js';
import { lit } from './lib.js';
import * as services from './api/services.js';
import * as auth from './auth/authentication.js';

// Import views render logic
import { homeController } from './controllers/homeController.js';
import { loginController } from './controllers/loginController.js';
import { registerController } from './controllers/registerController.js';
import { logoutController } from './controllers/logoutController.js';
import { listingsController } from './controllers/listingsController.js';
import { createController } from './controllers/createController.js';
import { detailsController } from './controllers/detailsController.js';
import { editController } from './controllers/editController.js';
import { deleteController } from './controllers/deleteController.js';
import { byYearController } from './controllers/byYearController.js';

// Select containers
const rootElement = document.body;
const viewContainer = document.getElementById('view-container');

// Register routes
page(decorateContext({ lit, services, auth, rootElement, viewContainer }));
page('/', homeController);
page('/login', loginController);
page('/register', registerController);
page('/logout', logoutController);
page('/listings', listingsController);
page('/create', createController);
page('/details/:id', detailsController);
page('/edit/:id', editController);
page('/delete/:id', deleteController);
page('/my-listings', listingsController);
page('/by-year', byYearController);

page.start();
