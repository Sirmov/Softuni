function solve(httpRequest) {
    const uriRegex = /^([*]|[a-zA-Z0-9.]+)$/g;
    const messageRegex = /^([^<>\\&'"]*)$/g;

    if (httpRequest.method !== 'GET' &&
        httpRequest.method !== 'POST' &&
        httpRequest.method !== 'DELETE' &&
        httpRequest.method !== 'CONNECT') {
        throwInvalidRequestHeaderError('Method');
    }

    if (!uriRegex.test(httpRequest.uri) || !httpRequest.hasOwnProperty('uri')) {
        throwInvalidRequestHeaderError('URI');
    }

    if (httpRequest.version !== 'HTTP/0.9' &&
        httpRequest.version !== 'HTTP/1.0' &&
        httpRequest.version !== 'HTTP/1.1' &&
        httpRequest.version !== 'HTTP/2.0') {
        throwInvalidRequestHeaderError('Version');
    }

    if (!messageRegex.test(httpRequest.message) || !httpRequest.hasOwnProperty('message')) {
        throwInvalidRequestHeaderError('Message');
    }

    return httpRequest;

    function throwInvalidRequestHeaderError(argument) {
        throw new Error(`Invalid request header: Invalid ${argument}`);
    }
}
