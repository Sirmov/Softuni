function firstAndLastKNumbers(arr) {
    let elements = arr.shift();
    console.log(arr.slice(0, elements).join(" "));
    console.log(arr.slice(arr.length - elements).join(" "));
}
