function solve(input) {
    let heroes = [];

    for (const line of input) {
        let [name, levelAsString, items] = line.split(' / ');
        let hero = {
            name,
            level: Number(levelAsString),
            items: items ? items.split(', ').filter(x => x.length > 0) : []
        }
        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes));
}
