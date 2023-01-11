function distinctArray(arr) {
    let distinctArray = [];

    for (const element of arr) {
        if (!distinctArray.includes(element)) {
            distinctArray.push(element);
        }
    }

    console.log(distinctArray.join(' '));
}
