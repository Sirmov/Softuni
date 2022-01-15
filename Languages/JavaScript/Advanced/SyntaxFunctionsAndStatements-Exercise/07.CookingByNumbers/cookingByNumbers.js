function solve(initialValue, c1, c2, c3, c4, c5) {
    let number = Number(initialValue);
    let commands = [];
    commands.push(c1, c2, c3, c4, c5);

    for (const command of commands) {
        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;
            default:
                break;
        }

        console.log(number);
    }
}
