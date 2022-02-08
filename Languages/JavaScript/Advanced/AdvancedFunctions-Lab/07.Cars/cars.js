function solve(input) {
    let objects = {};

    let closure = {
        create(name) {
            objects[name] = {};
        },
        createInherits(name, parentName) {
            let object = {};
            Object.setPrototypeOf(object, objects[parentName]);
            objects[name] = object;
        },
        set(name, key, value) {
            objects[name][key] = value;
        },
        print(name) {
            let object = objects[name];
            let ownProperties = Object.entries(object);
            let inheritedProperties = Object.entries(Object.getPrototypeOf(object));
            let properties = [];
            properties.push(ownProperties.map(kvp => `${kvp[0]}:${kvp[1]}`).join(','));
            properties.push(inheritedProperties.map(kvp => `${kvp[0]}:${kvp[1]}`).join(','));
            console.log(properties.join(','));
        }
    }

    input.forEach(element => {
        let arguments = element.split(' ');
        let operation = arguments[0];
        if (operation === 'create') {
            if (arguments[2] === 'inherit') {
                let [name, _, parentName] = arguments.slice(1);
                closure.createInherits(name, parentName);
            } else {
                closure.create(arguments[1]);
            }
        } else if (operation === 'set') {
            let [name, key, value] = arguments.slice(1);
            closure.set(name, key, value);
        } else if (operation === 'print') {
            closure.print(arguments[1]);
        }
    });
}

solve(['create c1', 'create c2 inherit c1', 'set c1 color red', 'set c2 model new', 'print c1', 'print c2']);
