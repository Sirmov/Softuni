function train(input) {
    let train = input.shift().split(' ').map(Number);
    let maxCapacity = Number(input.shift());
    let commands = input;

    while (commands.length > 0) {
        let command = commands.shift().split(' ');
        let operation = command[0];

        if (operation === 'Add') {
            let passengers = Number(command[1]);
            train.push(passengers);
        } else {
            let passengers = Number(command[0]);

            for (let i = 0; i < train.length; i++) {
                let freeSeats = maxCapacity - train[i];

                if (freeSeats >= passengers) {
                    train[i] += passengers;
                    break;
                }
            }
        }
    }

    console.log(train.join(' '));
}
