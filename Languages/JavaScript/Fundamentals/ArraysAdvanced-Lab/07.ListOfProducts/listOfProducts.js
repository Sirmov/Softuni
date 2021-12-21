function listOfProducts(arr) {
    arr.sort()
        .forEach((x, i) => console.log(`${i + 1}.${x}`));
}
