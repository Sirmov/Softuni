function ladybugs(input) {
    let fieldSize = input.shift();
    let bugsPositions = input.shift().split(' ').map(Number);
    let field = Array(fieldSize);
    field.fill(0);

    for (const index of bugsPositions) {
        if (isInside(field, index)) {
            field[index] = 1;
        }
    }

    while (input.length > 0) {
        let command = input.shift().split(' ');
        let index = Number(command[0]);
        let direction = command[1];
        let power = Number(command[2]);

        if (!isInside(field, index) || field[index] == 0 || power === 0) {
            continue;
        }

        field[index] = 0;

        do {
            if (direction == 'right') {
                index += power;
            } else {
                index -= power;
            }
        } while (isInside(field, index) && field[index] == 1);


        if (isInside(field, index)) {
            field[index] = 1;
        }
    }

    console.log(field.join(' '));

    function isInside(arr, index) {
        return index >= 0 && index < arr.length;
    }
}
