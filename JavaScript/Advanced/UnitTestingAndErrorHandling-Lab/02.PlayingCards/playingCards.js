function solve(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validSuits = ['S', 'H', 'D', 'C'];
    const suitsSymbols = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    if (!validFaces.includes(face) || !validSuits.includes(suit)) {
        throw new Error('Card face or suit is invalid!');
    }

    return {
        face,
        suit: suitsSymbols[suit],
        toString() {
            return `${this.face}${this.suit}`;
        }
    }
}
