function solve(area, volume, input) {
    let output = [];

    JSON.parse(input).forEach(element => {
        let object = {
            area: area.call(element, element.x, element.y),
            volume: volume.call(element, element.x, element.y, element.z)
        };
        output.push(object);
    });

    return output;
}
