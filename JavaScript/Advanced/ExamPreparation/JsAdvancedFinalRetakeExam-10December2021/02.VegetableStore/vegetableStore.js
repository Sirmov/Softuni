class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let addedProducts = new Set();

        vegetables.forEach(element => {
            let [type, quantity, price] = element.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            if (this.availableProducts.some(x => x.type === type)) {
                let product = this.availableProducts.find(x => x.type === type);
                product.quantity += quantity;
                product.price = Math.max(product.price, price);
            } else {
                this.availableProducts.push({ type, quantity, price });
            }

            addedProducts.add(type);
        });

        return `Successfully added ${Array.from(addedProducts.values()).join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        selectedProducts.forEach(element => {
            let [type, quantity] = element.split(' ');
            quantity = Number(quantity);

            if (!this.availableProducts.some(x => x.type === type)) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            } else {
                let product = this.availableProducts.find(x => x.type === type);

                if (product.quantity < quantity) {
                    throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
                }

                totalPrice += product.price * quantity;
                product.quantity -= quantity;
            }
        });

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        if (!this.availableProducts.some(x => x.type === type)) {
            throw new Error(`${type} is not available in the store.`);
        } else {
            let product = this.availableProducts.find(x => x.type === type);

            if (quantity > product.quantity) {
                product.quantity = 0;
                return `The entire quantity of the ${type} has been removed.`;
            } else {
                product.quantity -= quantity;
                return `Some quantity of the ${type} has been removed.`;
            }
        }
    }

    revision() {
        let output = 'Available vegetables:\n';
        output += this.availableProducts
            .sort((a, b) => a.price - b.price)
            .map(x => `${x.type}-${x.quantity}-$${x.price}`)
            .join('\n');
        output += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`;

        return output;
    }
}
