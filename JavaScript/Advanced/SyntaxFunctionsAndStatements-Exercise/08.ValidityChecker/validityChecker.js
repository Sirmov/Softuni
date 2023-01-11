function solve(x1, y1, x2, y2) {
    let firstPointDistance = Math.sqrt((0 - x1) ** 2 + (0 - y1) ** 2);
    let secondPointDistance = Math.sqrt((0 - x2) ** 2 + (0 - y2) ** 2);
    let PointToPointDistance = Math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2);

    if (Number.isInteger(firstPointDistance)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(secondPointDistance)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(PointToPointDistance)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}
