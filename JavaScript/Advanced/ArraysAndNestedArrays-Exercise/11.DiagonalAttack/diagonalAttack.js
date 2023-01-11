function solve(matrix) {
    matrix = matrix.map(row => row.split(' ').map(Number));

    let primaryDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        primaryDiagonalSum += matrix[i][i];
        secondaryDiagonalSum += matrix[i][matrix.length - 1 - i];
    }

    if (primaryDiagonalSum === secondaryDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (row === col || col === matrix.length - 1 - row) {
                    continue;
                }

                matrix[row][col] = primaryDiagonalSum;
            }
        }
    }

    for (const row of matrix) {
        console.log(row.join(' '));
    }
}
