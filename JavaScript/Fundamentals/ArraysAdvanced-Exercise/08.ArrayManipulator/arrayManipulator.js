function arrayManipulator(arr, commands) {
    while (commands.length > 0) {
        let command = commands.shift().split(' ');

        if (command[0] === 'add') {
            let index = Number(command[1]);
            let element = Number(command[2]);
            arr.splice(index, 0, element);
        } else if (command[0] === 'addMany') {
            let index = Number(command[1]);
            let elements = command.slice(2).map(Number);
            arr.splice(index, 0, ...elements);
        } else if (command[0] === 'contains') {
            let element = Number(command[1]);
            console.log(arr.indexOf(element));
        } else if (command[0] === 'remove') {
            let index = Number(command[1]);
            arr.splice(index, 1);
        } else if (command[0] === 'shift') {
            let positions = Number(command[1]);

            for (let i = 0; i < positions; i++) {
                arr.push(arr.shift());
            }
        } else if (command[0] === 'sumPairs') {
            let summedArr = [];

            for (let i = 0; i < arr.length - 1; i += 2) {
                summedArr.push(arr[i] + arr[i + 1]);
            }

            if (arr.length % 2 !== 0) {
                summedArr.push(arr.pop());
            }

            arr = summedArr;
        } else if (command[0] === 'print') {
            console.log(`[ ${arr.join(', ')} ]`);
            return;
        }
    }
}

arrayManipulator([1, 2, 3, 4, 5],
    ["sumPairs", "print"]);
