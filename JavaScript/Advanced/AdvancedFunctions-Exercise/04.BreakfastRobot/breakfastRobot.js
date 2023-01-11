function solve() {
    let recipes = {
        apple: {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2
        },
        lemonade: {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20
        },
        burger: {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            carbohydrate: 0,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    return function (instruction) {
        let arguments = instruction.split(' ');
        let operation = arguments[0];

        if (operation === 'restock') {
            let [microelement, quantity] = arguments.slice(1);
            ingredients[microelement] += Number(quantity);
            return `Success`;
        } else if (operation === 'prepare') {
            let [recipe, quantity] = arguments.slice(1);
            quantity = Number(quantity);

            for (const key in recipes[recipe]) {
                if (ingredients[key] < recipes[recipe][key] * quantity) {
                    return `Error: not enough ${key} in stock`;
                }
            }

            Object.keys(recipes[recipe]).forEach(key => {
                ingredients[key] -= recipes[recipe][key] * quantity;
            });

            return `Success`;
        } else if (operation === 'report') {
            return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
        }
    }
}
