class List {
    #elements;

    constructor() {
        this.#elements = [];
        this.size = 0;
    }

    add(element) {
        this.#elements.push(element);
        this.sort();
        this.size++;
    }

    remove(index) {
        if (index < 0 || index >= this.#elements.length) {
            throw new Error('Index out of range!')
        }

        this.#elements.splice(index, 1);
        this.size--;
    }

    get(index) {
        if (index < 0 || index >= this.#elements.length) {
            throw new Error('Index out of range!')
        }

        return this.#elements[index];
    }

    sort() {
        this.#elements.sort((a, b) => a - b);
    }
}
