function division(num) {
    let message;

    if (num % 10 == 0) {
        message = 'The number is divisible by 10';
    } else if (num % 7 == 0) {
        message = 'The number is divisible by 7';
    } else if (num % 6 == 0) {
        message = 'The number is divisible by 6';
    } else if (num % 3 == 0) {
        message = 'The number is divisible by 3';
    } else if (num % 2 == 0) {
        message = 'The number is divisible by 2';
    }
    else {
        message = 'Not divisible';
    }

    console.log(message);
}