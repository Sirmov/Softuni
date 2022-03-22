// Inject dependencies into context
const state = {};

export function addState(ctx, next) {
    ctx.state = state;

    next();
}
