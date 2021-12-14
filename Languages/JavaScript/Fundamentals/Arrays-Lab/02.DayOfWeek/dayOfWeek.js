function dayOfWeek(day) {
    let daysOfWeek =
        [
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday",
        ]

    if (day < 0 || day > 7) {
        console.log('Invalid day!');
    } else {
        console.log(daysOfWeek[day - 1]);
    }
}