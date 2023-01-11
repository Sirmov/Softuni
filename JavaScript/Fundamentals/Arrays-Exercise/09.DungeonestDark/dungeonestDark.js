function dungeonestDark(input = "") {
    let rooms = String(input).split('|');
    let health = 100;
    let coins = 0;
    let bestRoom = 1;

    for (const room of rooms) {
        let content = room.split(' ');
        let item = content[0];
        let value = Number(content[1]);

        if (item === 'potion') {
            health += value
            if (health > 100) {
                console.log(`You healed for ${100 - (health - value)} hp.`);
                health = 100;
            } else {
                console.log(`You healed for ${value} hp.`);
            }
            console.log(`Current health: ${health} hp.`);
        } else if (item === 'chest') {
            coins += value;
            console.log(`You found ${value} coins.`);
        } else {
            health -= value;

            if (health > 0) {
                console.log(`You slayed ${item}.`);
            } else {
                console.log(`You died! Killed by ${item}.`);
                console.log(`Best room: ${bestRoom}`);
                return;
            }
        }

        bestRoom++;
    }

    console.log("You've made it!");
    console.log(`Coins: ${coins}`);
    console.log(`Health: ${health}`);
}
