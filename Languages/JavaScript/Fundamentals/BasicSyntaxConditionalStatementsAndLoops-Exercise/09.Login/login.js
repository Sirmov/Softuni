function login(input) {
    let username = String(input[0]);
    let password = username.split('').reverse().join('');
    let tries = 1;

    while (true) {
        let currPassword = input[tries++];

        if (currPassword === password) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            if (tries === 5) {
                console.log(`User ${username} blocked!`);
                break;
            }

            console.log('Incorrect password. Try again.');
        }
    }
}
