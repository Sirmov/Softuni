function solve(input) {
    let cars = new Map();

    input.forEach(element => {
        let [brand, model, quantityAsString] = element.split(' | ');
        let quantity = Number(quantityAsString);

        if (!cars.has(brand)) {
            cars.set(brand, new Map());
        }

        if (!cars.get(brand).has(model)) {
            cars.get(brand).set(model, 0);
        }

        cars.get(brand).set(model, cars.get(brand).get(model) + quantity);
    });

    cars.forEach((v, k) => {
        console.log(k);
        v.forEach((v, k) => {
            console.log(`###${k} -> ${v}`);
        });
    });
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);
