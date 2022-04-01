import { readUserMemes } from '../services/memesService.js';
import { getUserData, getUserId } from '../utils/auth.js';
import { profileTemplate, memesTemplate } from '../views/profileView.js';

export function profileController(ctx, next) {
    ctx.render(profileTemplate(renderUserMemes()));
}

async function renderUserMemes() {
    let memes = await readUserMemes(getUserId());

    return memesTemplate(memes, getUserData());
}
