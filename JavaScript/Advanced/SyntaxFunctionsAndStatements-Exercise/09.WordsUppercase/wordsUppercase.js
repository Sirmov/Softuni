function solve(input = '') {
    let words = input
        .split(/[\W]+/g)
        .filter(x => x.length > 0)
        .map(x => x.toUpperCase());

    console.log(words.join(', '));
}
