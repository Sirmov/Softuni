function buildAWall(arr) {
    let crews = arr.map(Number);
    let priceForConcrete = 1900;
    let concrete = [];

    while (!crews.every(x => x === 30)) {
        let concreteForDay = 0;

        for (let i = 0; i < crews.length; i++) {
            if (crews[i] < 30) {
                crews[i]++;
                concreteForDay += 195;
            }
        }

        concrete.push(concreteForDay);
    }

    console.log(concrete.join(', '));
    console.log(`${concrete.reduce((a, b) => a + b) * priceForConcrete} pesos`);
}
