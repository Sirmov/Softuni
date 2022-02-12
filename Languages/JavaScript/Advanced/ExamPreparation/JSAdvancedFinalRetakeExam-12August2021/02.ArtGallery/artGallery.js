class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { picture: 200, photo: 50, item: 250 };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles[articleModel.toLowerCase()]) {
            throw new Error('This article model is not included in this gallery!');
        }

        let indexOfArticle = this.listOfArticles
            .indexOf(x => x.articleName === articleName && x.articleModel === articleModel);

        if (indexOfArticle !== -1) {
            this.listOfArticles[indexOfArticle].quantity += quantity;
        } else {
            this.listOfArticles.push({ articleModel: articleModel.toLowerCase(), articleName, quantity });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`)
        }

        let points;

        switch (personality) {
            case 'Vip':
                points = 500;
                break;
            case 'Middle':
                points = 250;
                break;
            default:
                points = 50;
                break;
        }
    }
}
