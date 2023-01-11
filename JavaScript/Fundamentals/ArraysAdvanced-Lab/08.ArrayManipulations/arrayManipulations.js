function arrayManipulations(input) {
    let arr = input.shift().split(' ').map(Number);

    while (input.length > 0) {
        let command = input.shift().split(' ');
        let operation = command[0];

        if (operation === 'Add') {
            let number = Number(command[1]);
            arr.push(number);
        } else if (operation === 'Remove') {
            let number = Number(command[1]);
            arr = arr.filter(x => x !== number);
        } else if (operation === 'RemoveAt') {
            let index = Number(command[1]);
            arr.splice(index, 1);
        } else if (operation === 'Insert') {
            let number = Number(command[1]);
            let index = Number(command[2]);
            arr.splice(index, 0, number);
        }
    }

    console.log(arr.join(' '));
}
