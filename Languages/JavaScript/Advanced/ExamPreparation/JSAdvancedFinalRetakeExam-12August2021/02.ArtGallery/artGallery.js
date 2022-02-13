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

        let article = this.listOfArticles
            .find(x => x.name === articleName && x.model === articleModel);

        if (article) {
            article.quantity += quantity;
        } else {
            this.listOfArticles.push({ model: articleModel.toLowerCase(), name: articleName, quantity });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.name === guestName)) {
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

        this.guests.push({ name: guestName, points, purchaseArticle: 0 });
        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        let article = this.listOfArticles.find(x => x.name === articleName);

        if (!article || article.model !== articleModel) {
            throw new Error('This article is not found.');
        }

        if (article.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this.guests.find(x => x.name === guestName);

        if (!guest) {
            return 'This guest is not invited.';
        }

        if (guest.points < this.possibleArticles[articleModel]) {
            return 'You need to more points to purchase the article.';
        } else {
            guest.points -= this.possibleArticles[articleModel];
            article.quantity--;
            guest.purchaseArticle++;
            return `${guestName} successfully purchased the article worth ${this.possibleArticles[articleModel]} points.`;
        }
    }

    showGalleryInfo(criteria) {
        if (criteria === 'article') {
            let output = 'Articles information:\n';
            output += this.listOfArticles
                .map(x => `${x.model} - ${x.name} - ${x.quantity}`)
                .join('\n');
            return output;
        } else if (criteria === 'guest') {
            let output = 'Guests information:\n';
            output += this.guests
                .map(x => `${x.name} - ${x.purchaseArticle}`)
                .join('\n');
            return output;
        }
    }
}

let art = new ArtGallery('gosho');
art.addArticle('picture', 'Mona Liza', 3);
