class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !position || !department || salary < 0) {
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

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
