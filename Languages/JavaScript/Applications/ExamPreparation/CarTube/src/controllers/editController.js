import { editTemplate } from '../views/editView.js';

const allowedData = ['brand', 'model', 'description', 'year', 'imageUrl', 'price'];

export async function editController(ctx, next) {
    let listing = await ctx.services.getListing(ctx.params.id);
    ctx.render(editTemplate(editSubmit, listing));

    async function editSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const formEntries = [...formData.entries()];
        const data = formEntries.reduce(
            (a, [k, v]) => (allowedData.includes(k) ? Object.assign(a, { [k]: v }) : a),
            {}
        );
        data.year = Number(data.year);
        data.price = Number(data.price);
        let errorMessages = [];

        if (Number.isNaN(data.year) || data.year <= 0) {
            errorMessages.push('Year must be a positive number!');
        }
        if (Number.isNaN(data.price) || data.price <= 0) {
            errorMessages.push('Price must be a positive number!');
        }
        if (!data.brand || !data.model || !data.description || !data.imageUrl) {
            errorMessages.push('Empty field!');
        }

        if (errorMessages.length === 0) {
            await ctx.services.putListing(ctx.params.id, data);
            ctx.page.redirect(`/details/${ctx.params.id}`);
        } else {
            alert(errorMessages.join(' '));
        }
    }
}
