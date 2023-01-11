import { delFurniture, getFurnitureDetails } from '../api/request.js';
import { getUserId } from '../auth/authentication.js';
import { detailsTemplate, furnitureDetailsTemplate } from '../templates.js';

// Export render function
export function renderFurnitureDetails(ctx, next) {
    ctx.render(detailsTemplate(renderDetails()));

    async function renderDetails() {
        let furniture = await getFurnitureDetails(ctx.params.id);
        const isOwner = getUserId() === furniture._ownerId;
        return furnitureDetailsTemplate(furniture, isOwner, editFurniture, deleteFurniture);
    }

    function editFurniture(event) {
        ctx.page.redirect(`/edit/${event.currentTarget.dataset.id}`);
    }

    async function deleteFurniture(event) {
        let choice = confirm('Are you sure that you want to delete this furniture?');

        if (choice) {
            await delFurniture(event.currentTarget.dataset.id);
            alert('Successfully deleted furniture!');
            ctx.page.redirect('/dashboard');
        }
    }
}
