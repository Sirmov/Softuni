function solve(moves) {
    let board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let isX = true;

    for (const move of moves) {
        let coordinates = move.split(' ').map(Number);
        let row = coordinates[0];
        let col = coordinates[1];

        if (!board[row][col]) {
            if (isX) {
                board[row][col] = 'X';
            } else {
                board[row][col] = 'O';
            }
        } else {
            console.log(`This place is already taken. Please choose another!`);
            continue;
        }

        if (checkForWinner(board)) {
            return;
        };

        if (isX) {
            ixX = false;
        } else {
            isX = true;
        }
    }

    console.log(`The game ended! Nobody wins :(`);
    for (const row of board) {
        console.log(row.join('\t'));
    }

    function checkForWinner(board) {
        let isWin = false;
        let winner;

        // checks rows
        for (let i = 0; i < board.length; i++) {
            let player = board[i][0];

            if (board[i].every(x => x === player)) {
                isWin = true;
                winner = player;
            }
        }

        // checks columns
        for (let col = 0; col < board.length; col++) {
            let player = board[0][col];
            let positions = [];

            for (let row = 0; row < board.length; row++) {
                positions.push(board[row][col]);
            }

            if (positions.every(x => x === player)) {
                isWin = true;
                winner = player;
            }
        }

        // checks primary diagonal
        for (let i = 0; i < board.length; i++) {
            let player = board[0][0];
            let positions = [];

            for (let j = 0; j < board.length; j++) {
                positions.push(board[j][j]);
            }

            if (positions.every(x => x === player)) {
                isWin = true;
                winner = player;
            }
        }

        // checks secondary diagonal
        for (let i = 0; i < board.length; i++) {
            let player = board[0][0];
            let positions = [];

            for (let i = 0; i < board.length; i++) {
                positions.push(board[i][board.length - 1 - i]);
            }

            if (positions.every(x => x === player)) {
                isWin = true;
                winner = player;
            }
        }

        if (isWin && winner !== false) {
            console.log(`Player ${winner} wins!`);
            for (const row of board) {
                console.log(row.join('\t'));
            }
            return true;
        }
    }
}

solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]);
