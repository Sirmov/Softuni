class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { child: 150, student: 300, collegian: 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        let price = this.priceForTheCamp[condition];

        if (!price) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(x => x.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < price) {
            return 'The money is not enough to pay the stay at the camp.';
        }

        this.listOfParticipants.push({ name, condition, power: 100, wins: 0 });
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        let participant = this.listOfParticipants.find(x => x.name === name);

        if (!participant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        } else {
            let index = this.listOfParticipants.indexOf(participant);
            this.listOfParticipants.splice(index, 1);
            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        let firstPlayer = this.listOfParticipants.find(x => x.name === participant1);

        if (!firstPlayer) {
            throw new Error('Invalid entered name/s.');
        }

        if (typeOfGame === 'WaterBalloonFights') {
            let secondPlayer = this.listOfParticipants.find(x => x.name === participant2);

            if (!secondPlayer) {
                throw new Error('Invalid entered name/s.');
            }

            if (firstPlayer.condition !== secondPlayer.condition) {
                throw new Error('Choose players with equal condition.');
            }

            if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins++;
                return `The ${firstPlayer.name} is winner in the game WaterBalloonFights.`;
            } else if (secondPlayer.power > firstPlayer.power) {
                secondPlayer.wins++;
                return `The ${secondPlayer.name} is winner in the game WaterBalloonFights.`;
            } else {
                return 'There is no winner.';
            }
        } else if (typeOfGame === 'Battleship') {
            firstPlayer.power += 20;
            return `The ${firstPlayer.name} successfully completed the game Battleship.`;
        }
    }

    toString() {
        let output = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;
        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        this.listOfParticipants.forEach(element => {
            output += `${element.name} - ${element.condition} - ${element.power} - ${element.wins}\n`;
        });

        return output.trimEnd();
    }
}
