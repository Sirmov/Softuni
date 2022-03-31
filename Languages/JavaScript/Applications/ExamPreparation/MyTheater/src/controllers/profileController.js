import { readUserTheaters } from '../services/theatersService.js';
import { getUserEmail, getUserId } from '../utils/auth.js';
import { eventsTemplate, profileTemplate } from '../views/profileView.js';

export function profileController(ctx, next) {
    ctx.render(profileTemplate(getUserEmail(), renderUserEvents()));
}

async function renderUserEvents() {
    let events = await readUserTheaters(getUserId());

    return eventsTemplate(events);
}
