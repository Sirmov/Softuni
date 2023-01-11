function solve(input) {
    let products = {};

    for (const line of input) {
        let [town, productName, price] = line.split(' | ');

        let product = {
            name: productName,
            town,
            price: Number(price)
        }

        let item = products[product.name];

        if (!item) {
            products[product.name] = product;
        } else {
            if (product.price < products[product.name].price) {
                item.town = product.town;
                item.price = product.price;
            }
        }
    }

    for (const key in products) {
        console.log(`${products[key].name} -> ${products[key].price} (${products[key].town})`);
    }
}
