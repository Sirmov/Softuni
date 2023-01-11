function solve(matrix) {
    let sum = matrix[0].reduce((acc, num) => acc + num);

    for (let row = 0; row < matrix.length; row++) {
        let rowSum = matrix[row].reduce((acc, num) => acc + num);

        if (rowSum !== sum) {
            return false;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let colSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            colSum += matrix[row][col];
        }

        if (colSum !== sum) {
            return false;
        }
    }

    return true;
}
