// Application entry point

// Import middleware
import { renderMiddleware } from './middleware/renderMiddleware.js';

// Import dependencies
import { page } from './utils/lib.js';

// Import views render logic
import { loginController } from './controllers/loginController.js';
import { registerController } from './controllers/registerController.js';


// Register routes
page(renderMiddleware);
page('/login', loginController);
page('/register', registerController);

page.start();
