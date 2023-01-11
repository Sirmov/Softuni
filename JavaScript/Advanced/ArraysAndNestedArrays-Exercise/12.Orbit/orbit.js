function solve(input) {
    let [rows, cols, starX, starY] = input;

    let matrix = Array(rows);

    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = Array(cols).fill(0);
    }

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            matrix[row][col] = Math.max(Math.abs(col - starY) + 1, Math.abs(row - starX) + 1);
        }
    }

    for (const row of matrix) {
        console.log(row.join(' '));
    }
}
