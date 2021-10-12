function thePyramidOfKingDjoser(base, height) {
    let width = base;

    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 0;

    let steps = 1;

    while (width > 0) {
        if (width - 2 <= 0) {
            gold += width * width * height;
            width -= 2;
        } else if (steps % 5 == 0) {
            stone += ((width - 2) * (width - 2)) * height;
            lapisLazuli += (width * 4 - 4) * height;
            width -= 2;
        } else {
            stone += ((width - 2) * (width - 2)) * height;
            marble += (width * 4 - 4) * height;
            width -= 2;
        }

        steps++;
    }

    steps -= 1;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(steps * height)}`);
}
