import { getAllFurniture, getMyFurniture } from '../api/request.js';
import { getUserId } from '../auth/authentication.js';
import { dashboardTemplate, furnitureTemplate } from '../templates.js';

// Export render function
export function renderDashboard(ctx, next) {
    let isMyFurniture = ctx.page.current === '/my-furniture';
    ctx.setActive();
    ctx.render(dashboardTemplate(renderFurniture(isMyFurniture), isMyFurniture));
}

async function renderFurniture(isMyFurniture) {
    let furniture;

    if (isMyFurniture) {
        furniture = await getMyFurniture(getUserId());
    } else {
        furniture = await getAllFurniture();
    }

    return furnitureTemplate(furniture);
}
