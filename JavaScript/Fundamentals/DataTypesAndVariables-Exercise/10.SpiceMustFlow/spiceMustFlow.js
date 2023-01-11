function spiceMustFlow(spiceYield) {
    let spice = 0;
    let days = 0;

    while (spiceYield >= 100) {
        spice += spiceYield - 26;
        days++;
        spiceYield -= 10;
    }

    spice = spice - 26 < 0 ? 0 : spice - 26;

    console.log(days);
    console.log(spice);
}
