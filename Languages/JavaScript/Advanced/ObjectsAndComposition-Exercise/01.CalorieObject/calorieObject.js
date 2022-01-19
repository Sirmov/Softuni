function solve(input) {
    let foods = {};

    for (let i = 0; i < input.length; i += 2) {
        let foodName = input[i];
        let calories = Number(input[i + 1]);
        foods[foodName] = calories;
    }

    return foods;
}
