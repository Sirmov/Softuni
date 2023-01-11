function generateReport() {
    let checkBoxElements = Array.from(document.querySelectorAll('thead tr th input'));
    let checkedColumns = checkBoxElements.filter(x => x.checked);
    let rows = Array.from(document.querySelectorAll('tbody tr'));

    let employees = [];

    rows.forEach(element => {
        let info = element.children;
        let employee = {};

        checkedColumns.forEach(col => {
            employee[col.name] = info[checkBoxElements.indexOf(col)].textContent;
        });

        employees.push(employee);
    });

    document.getElementById('output').value = JSON.stringify(employees);
}
