function amazingNumber(num) {
    let digitSum = 0;
    let temp = Number(num);

    while (temp != 0) {
        digitSum += temp % 10;
        temp = Math.floor(temp / 10);
    }

    console.log(`${num} Amazing? ${digitSum.toString().includes('9') ? 'True' : 'False'}`);
}
