function addAndSubtract(arr = []) {
    let modifiedArray =
        arr.map(x => x % 2 == 0 ? x + arr.indexOf(x) : x - arr.indexOf(x));
        
    console.log(modifiedArray);
    console.log(arr.reduce((x, y) => x + y));
    console.log(modifiedArray.reduce((x, y) => x + y));
}
