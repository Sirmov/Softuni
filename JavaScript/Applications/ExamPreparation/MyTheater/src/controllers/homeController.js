import { readAllTheaters } from '../services/theatersService.js';
import { eventsTemplate, homeTemplate } from '../views/homeView.js';

export function homeController(ctx, next) {
    ctx.render(homeTemplate(renderEvents()));
}

async function renderEvents() {
    let events = await readAllTheaters();

    return eventsTemplate(events);
}
