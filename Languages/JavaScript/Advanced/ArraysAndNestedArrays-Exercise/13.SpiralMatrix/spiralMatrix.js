function solve(rows, cols) {
    let matrix = Array(rows);

    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = Array(cols);
    }

    let num = 1;
    let direction = 'right';
    let topBorder = 0;
    let bottomBorder = rows - 1;
    let rightBorder = cols - 1;
    let leftBorder = 0;

    while (topBorder <= bottomBorder && leftBorder <= rightBorder) {
        if (direction === 'right') {
            for (let col = leftBorder; col <= rightBorder; col++) {
                matrix[topBorder][col] = num++;
            }

            topBorder++;
            direction = 'down';
        } else if (direction === 'down') {
            for (let row = topBorder; row <= bottomBorder; row++) {
                matrix[row][rightBorder] = num++;
            }

            rightBorder--;
            direction = 'left';
        } else if (direction === 'left') {
            for (let col = rightBorder; col >= leftBorder; col--) {
                matrix[bottomBorder][col] = num++;
            }

            bottomBorder--;
            direction = 'up';
        } else if (direction === 'up') {
            for (let row = bottomBorder; row >= topBorder; row--) {
                matrix[row][leftBorder] = num++;
            }

            leftBorder++;
            direction = 'right';
        }
    }

    for (const row of matrix) {
        console.log(row.join(' '));
    }
}
