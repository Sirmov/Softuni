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
import { dashboardController } from './controllers/dashboardController.js';
import { logoutAction } from './actions/logoutAction.js';
import { createController } from './controllers/createController.js';
import { detailsController } from './controllers/detailsController.js';
import { editController } from './controllers/editController.js';
import { deleteBookAction } from './actions/deleteBookAction.js';
import { myBooksController } from './controllers/myBooksController.js';
import { likeBookAction } from './actions/likeBookAction.js';

// Register routes
page(dependenciesMiddleware({ auth }));
page(renderMiddleware);
page('/login', loginController);
page('/register', registerController);
page('/logout', logoutAction);
page('/', dashboardController);
page('/add-book', createController);
page('/details/:id', detailsController);
page('/edit/:id', editController);
page('/delete/:id', deleteBookAction);
page('/my-books', myBooksController);
page('/like/:id', likeBookAction)

page.start();
