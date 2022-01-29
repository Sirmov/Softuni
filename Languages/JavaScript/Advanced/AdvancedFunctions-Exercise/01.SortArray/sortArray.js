function solve(array, order) {
    if (order === 'asc') {
        return array.sort((a, b) => a - b);
    } else if (order === 'desc') {
        return array.sort((a, b) => b - a);
    }
}
