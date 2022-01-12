function solve(fruit, weight, pricePerKilogram) {
    weight /= 1000;
    let price = weight * pricePerKilogram;
    console.log(`I need $${price.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}
