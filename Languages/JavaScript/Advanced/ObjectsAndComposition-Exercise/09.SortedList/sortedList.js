function solve() {
    let list = {
        elements: [],
        add(element) {
            this.elements.push(element);
            this.elements.sort((a, b) => a - b);
        },
        remove(index) {
            if (index >= 0 && index < this.elements.length) {
                this.elements.splice(index, 1);
                this.elements.sort((a, b) => a - b);
            }
        },
        get(index) {
            if (index >= 0 && index < this.elements.length) {
                return this.elements[index];
            }
        },
        get size() {
            return this.elements.length
        }
    }

    return list;
}
