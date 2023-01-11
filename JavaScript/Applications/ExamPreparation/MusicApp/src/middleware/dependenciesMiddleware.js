// Inject dependencies into context

export function dependenciesMiddleware(dependencies) {
    return function (ctx, next) {
        Object.assign(ctx, dependencies);

        next();
    };
}
