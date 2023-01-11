function specialNumbers(num) {
  for (let i = 1; i <= num; i++) {
    let digitsSum = 0;
    let temp = i;

    while (temp != 0) {
      digitsSum += temp % 10;
      temp = Math.trunc(temp / 10);
    }

    let isSpecial = digitsSum == 5 || digitsSum == 7 || digitsSum == 11;
    console.log(`${i} -> ${isSpecial ? 'True' : 'False'}`);
  }
}
