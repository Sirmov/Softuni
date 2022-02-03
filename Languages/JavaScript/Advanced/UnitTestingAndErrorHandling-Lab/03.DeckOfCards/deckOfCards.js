function solve(inputCards) {
    let cards = [];

    for (const element of inputCards) {
        let characters = element.split('');
        let suit = characters.splice(-1, 1)[0];
        let face = characters.join('');

        try {
            let card = createCard(face, suit);
            cards.push(card);
        } catch (error) {
            console.log(error.message);
            return;
        }
    }

    console.log(cards.join(' '));

    function createCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = ['S', 'H', 'D', 'C'];
        const suitsSymbols = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        }

        if (!validFaces.includes(face) || !validSuits.includes(suit)) {
            throw new Error(`Invalid card: ${face + suit}`);
        }

        return {
            face,
            suit: suitsSymbols[suit],
            toString() {
                return `${this.face}${this.suit}`;
            }
        }
    }
}
