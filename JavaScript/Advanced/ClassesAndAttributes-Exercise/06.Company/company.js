class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !position || !department || !salary || salary < 0) {
            throw new Error('Invalid input!');
        }

        let employee = { name, salary, position };

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = Object.entries(this.departments).sort(sortDepartments)[0];

        function sortDepartments(a, b) {
            let aAverageSalary = a[1].reduce((a, e) => a + e.salary, 0);
            aAverageSalary /= a[1].length;

            let bAverageSalary = b[1].reduce((a, e) => a + e.salary, 0);
            bAverageSalary /= b[1].length;

            return bAverageSalary - aAverageSalary;
        }

        bestDepartment[1].sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));
        let averageSalary = bestDepartment[1].reduce((a, e) => a + e.salary / bestDepartment[1].length, 0);

        let output = `Best Department is: ${bestDepartment[0]}\n`;
        output += `Average salary: ${averageSalary.toFixed(2)}\n`;
        bestDepartment[1].forEach(e => {
            output += `${e.name} ${e.salary} ${e.position}\n`;
        });

        return output.trimEnd();
    }
}
