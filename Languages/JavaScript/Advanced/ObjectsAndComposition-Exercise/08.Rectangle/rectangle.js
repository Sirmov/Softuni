function solve(width, height, color) {
    let rectangle = {
        width,
        height,
        color: color[0].toUpperCase() + color.slice(1),
        calcArea() {
            return this.width * this.height;
        }
    }

    return rectangle;
}
