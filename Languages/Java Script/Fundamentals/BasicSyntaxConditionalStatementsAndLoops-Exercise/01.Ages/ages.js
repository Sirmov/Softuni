function ages(age) {
    let lifeStage;

    if (age < 0) {
        lifeStage = 'out of bounds';
    } else if (age <= 2) {
        lifeStage = 'baby';
    } else if (age <= 13) {
        lifeStage = 'child';
    } else if (age <= 19) {
        lifeStage = 'teenager';
    } else if (age <= 65) {
        lifeStage = 'adult';
    } else if (age >= 66) {
        lifeStage = 'elder';
    }

    console.log(lifeStage);
}
