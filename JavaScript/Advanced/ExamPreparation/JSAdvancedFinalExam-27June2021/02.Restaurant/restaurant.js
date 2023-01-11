class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        let actions = [];

        products.forEach(element => {
            let [name, quantity, totalPrice] = element.split(' ');
            quantity = Number(quantity);
            totalPrice = Number(totalPrice);

            if (this.budgetMoney >= totalPrice) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += quantity;
                this.budgetMoney -= totalPrice;
                actions.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                actions.push(`There was not enough money to load ${quantity} ${name}`);
            }
        });

        this.history.push(...actions);

        return actions.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        let mealObj = { products: {}, price };

        neededProducts.forEach(element => {
            let [name, quantity] = element.split(' ');
            quantity = Number(quantity);

            if (!mealObj.products[name]) {
                mealObj.products[name] = 0;
            }

            mealObj.products[name] += quantity;
        });

        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        this.menu[meal] = mealObj;

        if (Object.entries(this.menu).length === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else {
            return `Great idea! Now with the ${meal} we have ${Object.entries(this.menu).length} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        let meals = Object.entries(this.menu);

        if (meals.length === 0) {
            return 'Our menu is not ready yet, please come later...';
        } else {
            return meals.map(x => `${x[0]} - $ ${x[1].price}`).join('\n');
        }
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let canMake = true;

        Object.entries(this.menu[meal].products).forEach(([name, quantity]) => {
            if (!this.stockProducts[name] || this.stockProducts[name] < quantity) {
                canMake = false;
            }
        });

        if (!canMake) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }

        Object.entries(this.menu[meal].products).forEach(([name, quantity]) => {
            quantity = Number(quantity);
            this.stockProducts[name] -= quantity;
        });

        this.budgetMoney += this.menu[meal].price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}
