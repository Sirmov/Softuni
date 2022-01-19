function solve(input) {
    input.shift();
    let cities = [];

    for (const line of input) {
        let [Town, Latitude, Longitude] = line.split(/ *\| */g).filter(x => x.length > 0);
        let city = {
            Town,
            Latitude: Number(Number(Latitude).toFixed(2)),
            Longitude: Number(Number(Longitude).toFixed(2))
        };
        cities.push(city);
    }

    console.log(JSON.stringify(cities));
}
