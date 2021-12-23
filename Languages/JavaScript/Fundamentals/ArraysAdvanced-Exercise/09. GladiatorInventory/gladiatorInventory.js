function gladiatorInventory(commands) {
    let inventory = commands.shift().split(' ');

    while (commands.length > 0) {
        let command = commands.shift().split(' ');
        let operation = command[0];
        let equipment = command[1];

        if (operation === 'Buy') {
            if (!inventory.includes(equipment)) {
                inventory.push(equipment);
            }
        } else if (operation === 'Trash') {
            inventory = inventory.filter(x => x !== equipment);
        } else if (operation === 'Repair') {
            if (inventory.includes(equipment)) {
                inventory.push(inventory.splice(inventory.indexOf(equipment), 1));
            }
        } else if (operation === 'Upgrade') {
            let operationInfo = equipment.split('-');
            equipment = operationInfo[0];
            let upgrade = operationInfo[1];

            if (inventory.includes(equipment)) {
                let index = inventory.indexOf(equipment);
                inventory.splice(index + 1, 0, inventory[index] + `:${upgrade}`);
            }
        }
    }

    console.log(inventory.join(' '));
}
