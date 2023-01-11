function printAndSum(start, end) {
    let collection = "";
    let sum = 0;

    for (let i = start; i <= end; i++) {
        collection += i + " ";
        sum += i;
    }

    console.log(collection);
    console.log(`Sum: ${sum}`);
}
