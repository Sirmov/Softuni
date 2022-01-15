function solve(commands) {
    let output = [];
    let num = 1;

    for (const command of commands) {
        if (command === 'add') {
            output.push(num);
        } else if (command === 'remove') {
            output.pop();
        }

        num++;
    }

    console.log(output.length == 0 ? 'Empty' : output.join('\n'));
}
