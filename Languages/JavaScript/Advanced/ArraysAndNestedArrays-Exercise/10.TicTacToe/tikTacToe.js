function solve(moves) {
    let board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let player = 'X';

    for (const move of moves) {
        let coordinates = move.split(' ').map(Number);
        let row = coordinates[0];
        let col = coordinates[1];

        if (!board[row][col]) {
            board[row][col] = player;
        } else {
            console.log(`This place is already taken. Please choose another!`);
            continue;
        }

        if (checkForWinner(board, player)) {
            return;
        };

        if (board.every(row => row.every(x => x !== false))) {
            console.log(`The game ended! Nobody wins :(`);
            for (const row of board) {
                console.log(row.join('\t'));
            }

            return;
        }

        if (player === 'X') {
            player = 'O';
        } else {
            player = 'X';
        }
    }

    function checkForWinner(board, player) {
        let isWin = false;

        for (let row = 0; row < board.length; row++) {
            if (board[row].every(x => x === player)) {
                isWin = true;
            }
        }

        for (let col = 0; col < board.length; col++) {
            let positions = [];

            for (let row = 0; row < board.length; row++) {
                positions.push(board[row][col]);
            }

            if (positions.every(x => x === player)) {
                isWin = true;
            }
        }

        let primaryDiagonal = [];
        let secondaryDiagonal = [];

        for (let i = 0; i < board.length; i++) {
            primaryDiagonal.push(board[i][i]);
            secondaryDiagonal.push(board[i][board.length - 1 - i]);
        }

        if (primaryDiagonal.every(x => x === player) || secondaryDiagonal.every(x => x === player)) {
            isWin = true;
        }

        if (isWin) {
            console.log(`Player ${player} wins!`);

            for (const row of board) {
                console.log(row.join('\t'));
            }

            return true;
        }
    }
}
