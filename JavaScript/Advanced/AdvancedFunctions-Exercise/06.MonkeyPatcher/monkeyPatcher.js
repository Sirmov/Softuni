function solve(operation) {
    if (operation === 'upvote') {
        this.upvotes++;
    } else if (operation === 'downvote') {
        this.downvotes++;
    } else if (operation === 'score') {
        let totalVotes = this.upvotes + this.downvotes;
        let reportedUpvotes = this.upvotes;
        let reportedDownvotes = this.downvotes;
        let balance = this.upvotes - this.downvotes;
        let rating;

        if (totalVotes > 50) {
            let bonus = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);
            reportedUpvotes += bonus;
            reportedDownvotes += bonus;
        }

        if (balance < 0) {
            rating = 'unpopular';
        }

        if (totalVotes > 100 && balance >= 0) {
            rating = 'controversial';
        }

        if ((this.upvotes / totalVotes) * 100 > 66) {
            rating = 'hot';
        }

        if (totalVotes < 10 || !rating) {
            rating = 'new';
        }

        return [reportedUpvotes, reportedDownvotes, balance, rating];
    }
}
