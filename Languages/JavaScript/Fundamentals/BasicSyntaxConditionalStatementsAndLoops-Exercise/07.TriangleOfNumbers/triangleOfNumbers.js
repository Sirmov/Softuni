function triangleOfNumbers(rows) {
    for (let i = 1; i <= rows; i++) {
        let row = "";

        for (let j = 0; j < i; j++) {
            row += `${i} `;
        }

        console.log(row);
    }
}
