function vacation(peopleCount, groupType, weekDay) {
    let pricePerPerson = 0;
    let discount = 0;

    if (groupType === 'Students') {
        if (weekDay === 'Friday') {
            pricePerPerson = 8.45;
        } else if (weekDay === 'Saturday') {
            pricePerPerson = 9.80;
        } else if (weekDay === 'Sunday') {
            pricePerPerson = 10.46;
        }

        if (peopleCount >= 30) {
            discount = 0.15;
        }
    } else if (groupType === 'Business') {
        if (weekDay === 'Friday') {
            pricePerPerson = 10.90;
        } else if (weekDay === 'Saturday') {
            pricePerPerson = 15.60;
        } else if (weekDay === 'Sunday') {
            pricePerPerson = 16.00;
        }

        if (peopleCount >= 100) {
            peopleCount -= 10;
        }
    } else if (groupType === 'Regular') {
        if (weekDay === 'Friday') {
            pricePerPerson = 15;
        } else if (weekDay === 'Saturday') {
            pricePerPerson = 20;
        } else if (weekDay === 'Sunday') {
            pricePerPerson = 22.50;
        }

        if (peopleCount >= 10 && peopleCount <= 20) {
            discount = 0.05;
        }
    }

    let totalPrice = pricePerPerson * peopleCount;
    totalPrice -= totalPrice * discount;
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
