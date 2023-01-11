function extensibleObject() {
    return {
        extend(template) {
            let entries = Object.entries(template);

            for (const [key, value] of entries) {
                if (typeof value === 'function') {
                    Object.getPrototypeOf(this)[key] = value;
                } else {
                    this[key] = value;
                }
            }
        }
    };
}
