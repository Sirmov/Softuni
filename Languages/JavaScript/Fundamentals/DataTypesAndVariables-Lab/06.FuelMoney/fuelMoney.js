function fuelMoney(distance, passengers, fuelPrice) {
    let fuelNeeded = 7 * (distance / 100) + passengers * 0.1;
    let moneyNeeded = fuelNeeded * fuelPrice;

    console.log(`Needed money for that trip is ${moneyNeeded} lv.`);
}
