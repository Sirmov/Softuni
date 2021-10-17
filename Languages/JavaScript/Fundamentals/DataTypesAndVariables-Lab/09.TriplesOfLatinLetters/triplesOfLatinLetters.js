function triplesOfLatinLetters(num) {
    for (let i = 0; i < num; i++) {
        for (let j = 0; j < num; j++) {
            for (let k = 0; k < num; k++) {
                let firstLetter = String.fromCharCode(97 + i);
                let secondLetter = String.fromCharCode(97 + j);
                let thirdLetter = String.fromCharCode(97 + k);
                
                console.log(`${firstLetter}${secondLetter}${thirdLetter}`);
            }
        }
    }
}
