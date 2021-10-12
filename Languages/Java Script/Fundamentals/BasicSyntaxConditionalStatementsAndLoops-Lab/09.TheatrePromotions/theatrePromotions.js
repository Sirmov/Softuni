function theatrePromotions(typeOfDay, age) {
    let price;

    if (typeOfDay === 'Weekday') {
        if (age >= 0 && age <= 18) {
            price = 12;
        } else if (age >= 0 && age <= 64) {
            price = 18;
        } else if (age >= 0 && age <= 122) {
            price = 12;
        } else {
            price = 'Error!';
        }
    }
    else if (typeOfDay === 'Weekend') {
        if (age >= 0 && age <= 18) {
            price = 15;
        } else if (age >= 0 && age <= 64) {
            price = 20;
        } else if (age >= 0 && age <= 122) {
            price = 15;
        } else {
            price = 'Error!';
        }
    }
    else if (typeOfDay === 'Holiday') {
        if (age >= 0 && age <= 18) {
            price = 5;
        } else if (age >= 0 && age <= 64) {
            price = 12;
        } else if (age >= 0 && age <= 122) {
            price = 10;
        } else {
            price = 'Error!';
        }
    }

    if (price === 'Error!') {
        console.log(price);
    } else {
        console.log(`${price}$`);
    }
}
