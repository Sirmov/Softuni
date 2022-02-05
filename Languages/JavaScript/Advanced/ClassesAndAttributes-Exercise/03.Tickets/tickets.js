function solve(ticketInformation, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    ticketInformation.forEach(element => {
        let [destination, price, status] = element.split('|');
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    });

    if (sortingCriteria == 'status' || sortingCriteria == 'destination') {
        tickets.sort((a, b) => a[sortingCriteria].localeCompare(b[sortingCriteria]));
    } else {
        tickets.sort((a, b) => a[sortingCriteria] - b[sortingCriteria]);
    }
    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));
