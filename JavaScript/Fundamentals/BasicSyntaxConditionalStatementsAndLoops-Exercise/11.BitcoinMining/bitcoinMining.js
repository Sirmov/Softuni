function bitcoinMining(miningDays) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;

    let money = 0;
    let bitcoins = 0;
    let firstBitcoinDay = -1;

    for (let i = 0; i < miningDays.length; i++) {
        let gold = miningDays[i];

        if ((i + 1) % 3 === 0) {
            gold -= gold * 0.3;
        }

        money += gold * goldPrice;

        if (money >= bitcoinPrice) {
            if (firstBitcoinDay === -1) {
                firstBitcoinDay = i + 1;
            }

            while (money >= bitcoinPrice) {
                money -= bitcoinPrice;
                bitcoins++;
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoins}`);

    if (firstBitcoinDay !== -1) {
        console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`);
    }

    console.log(`Left money: ${money.toFixed(2)} lv.`);
}
