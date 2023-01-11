import { getUserData } from '../utils/auth.js';

export function sessionMiddleware(ctx, next) {
    ctx.user = getUserData();
}
