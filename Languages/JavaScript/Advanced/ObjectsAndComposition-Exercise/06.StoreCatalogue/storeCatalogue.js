function solve(input) {
    let products = [];

    for (const line of input) {
        let [name, price] = line.split(' : ');
        let product = {
            name,
            price: Number(price)
        }
        products.push(product);
    }

    products.sort((a, b) => a.name.localeCompare(b.name));

    let catalog = {};

    for (const item of products) {
        if (!catalog[item.name[0]]) {
            catalog[item.name[0]] = [];
        }

        catalog[item.name[0]].push(item);
    }

    for (const [key, value] of Object.entries(catalog)) {
        console.log(key);
        for (const item of value) {
            console.log(`  ${item.name}: ${item.price}`);
        }
    }
}
