function solve(input) {
    let collection = [];

    let processor = {
        add(element) {
            collection.push(element);
        },
        remove(element) {
            collection = collection.filter(x => x !== element);
        },
        print() {
            console.log(collection.join(','));
        }
    }

    input.forEach(element => {
        let [operation, argument] = element.split(' ');
        processor[operation](argument);
    });
}

solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);
