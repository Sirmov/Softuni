function solve(data, criteria) {
    let employees = JSON.parse(data);
    let [propName, propValue] = criteria.split('-');

    if (criteria !== 'all') {
        employees = employees.filter(x => x[propName] === propValue);
    }

    employees.forEach((element, i) => {
        console.log(`${i}. ${element.first_name} ${element.last_name} - ${element.email}`);
    })
}
