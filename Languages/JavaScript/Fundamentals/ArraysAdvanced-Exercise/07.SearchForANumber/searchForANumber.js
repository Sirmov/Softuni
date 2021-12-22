function searchForANumber(collection, manipulations) {
    let manipulatedCollection = [];
    let addCount = manipulations[0];
    let removeCount = manipulations[1];
    let specialNumber = manipulations[2];

    for (let i = 0; i < addCount; i++) {
        manipulatedCollection.push(collection.shift());
    }

    for (let i = 0; i < removeCount; i++) {
        manipulatedCollection.shift();
    }

    let occurrences = manipulatedCollection.reduce((count, current) =>
        current === specialNumber ? ++count : count, 0);

    console.log(`Number ${specialNumber} occurs ${occurrences} times.`);
}
