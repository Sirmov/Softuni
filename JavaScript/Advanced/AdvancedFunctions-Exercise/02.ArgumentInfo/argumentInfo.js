function solve() {
    let typeCount = {};

    for (let i = 0; i < arguments.length; i++) {
        let argumentType = typeof arguments[i];

        console.log(`${argumentType}: ${arguments[i]}`);

        if (!typeCount[argumentType]) {
            typeCount[argumentType] = 0;
        }

        typeCount[argumentType]++;
    }

    Object.entries(typeCount)
        .sort((a, b) => b[1] - a[1])
        .forEach(x => console.log(`${x[0]} = ${x[1]}`));
}

solve('cat', 42, function () { console.log('Hello world!'); });
