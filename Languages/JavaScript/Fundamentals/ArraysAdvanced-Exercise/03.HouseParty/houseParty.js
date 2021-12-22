function houseParty(input) {
    let party = [];

    while (input.length > 0) {
        let command = input.shift().split(' ');
        let name = command[0];
        let operation = command[2];

        if (operation === 'going!') {
            if (party.includes(name)) {
                console.log(`${name} is already in the list!`);
            } else {
                party.push(name);
            }
        } else if (operation === 'not') {
            if (party.includes(name)) {
                party.splice(party.indexOf(name), 1);
            } else {
                console.log(`${name} is not in the list!`);
            }
        }
    }

    console.log(party.join('\n'));
}
