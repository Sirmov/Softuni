function solve(carRequest) {
    let car = {};
    car.model = carRequest.model;

    if (carRequest.power <= 90) {
        car.engine = { power: 90, volume: 1800 };
    } else if (carRequest.power <= 120) {
        car.engine = { power: 120, volume: 2400 };
    } else {
        car.engine = { power: 200, volume: 3500 };
    }

    car.carriage = { type: carRequest.carriage, color: carRequest.color };

    let { wheelsize } = carRequest;

    if (wheelsize % 2 === 0) {
        car.wheels = [wheelsize - 1, wheelsize - 1, wheelsize - 1, wheelsize - 1];
    } else {
        car.wheels = [wheelsize, wheelsize, wheelsize, wheelsize];
    }

    return car;
}
