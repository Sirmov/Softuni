function solve(steps, stepLength, speed) {
    let distance = steps * stepLength;
    speed = speed * 1000 / 3600;
    let seconds = distance / speed;

    seconds += Math.floor(distance / 500) * 60;

    let hours = Math.floor(seconds / 3600);
    let minutes = Math.floor(seconds / 60);
    seconds -= hours * 3600 + minutes * 60;

    console.log(`${hours.toFixed(0).padStart(2, '0')}:${minutes.toFixed(0).padStart(2, '0')}:${seconds.toFixed(0).padStart(2, '0')}`);
}
