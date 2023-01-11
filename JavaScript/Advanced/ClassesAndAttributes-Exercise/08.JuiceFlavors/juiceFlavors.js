function solve(input) {
    let juices = new Map();
    let juiceBottles = new Map();

    input.forEach(element => {
        let [juice, quantityAsString] = element.split(' => ');
        let quantity = Number(quantityAsString);

        if (!juices.has(juice)) {
            juices.set(juice, 0);
        }

        juices.set(juice, juices.get(juice) + quantity);

        if (juices.get(juice) >= 1000) {
            let bottles = Math.floor(juices.get(juice) / 1000);
            juices.set(juice, juices.get(juice) - 1000 * bottles);

            if (!juiceBottles.has(juice)) {
                juiceBottles.set(juice, 0);
            }

            juiceBottles.set(juice, juiceBottles.get(juice) + bottles);
        }
    });

    juiceBottles.forEach((v, k) => console.log(`${k} => ${v}`));
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);
