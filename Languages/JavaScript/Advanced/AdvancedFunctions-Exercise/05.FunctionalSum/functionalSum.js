function solve(n) {
    let sum = n;

    function add(n) {
        sum += n;
        return add;
    }

    add.toString = () => sum;

    return add;
}
