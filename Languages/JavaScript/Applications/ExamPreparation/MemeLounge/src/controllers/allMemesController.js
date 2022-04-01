import { readAllMemes } from '../services/memesService.js';
import { allMemesTemplate, memesTemplate } from '../views/allMemesView.js';

export function allMemesController(ctx, next) {
    ctx.render(allMemesTemplate(renderMemes()));
}

async function renderMemes() {
    let memes = await readAllMemes();

    return memesTemplate(memes);
}
