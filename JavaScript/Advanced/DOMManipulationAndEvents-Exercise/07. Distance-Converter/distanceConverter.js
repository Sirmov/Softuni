function attachEventsListeners() {
    let convertButton = document.getElementById('convert');
    convertButton.addEventListener('click', (e) => {
        let inputDistance = Number(document.getElementById('inputDistance').value);
        let inputUnits = document.getElementById('inputUnits').value;
        let outputUnits = document.getElementById('outputUnits').value;

        let meters;

        switch (inputUnits) {
            case 'km':
                meters = inputDistance * 1000;
                break;
            case 'm':
                meters = inputDistance;
                break;
            case 'cm':
                meters = inputDistance * 0.01;
                break;
            case 'mm':
                meters = inputDistance * 0.001;
                break;
            case 'mi':
                meters = inputDistance * 1609.34;
                break;
            case 'yrd':
                meters = inputDistance * 0.9144;
                break;
            case 'ft':
                meters = inputDistance * 0.3048;
                break;
            case 'in':
                meters = inputDistance * 0.0254;
                break;
        }

        let outputDistance;

        switch (outputUnits) {
            case 'km':
                outputDistance = meters / 1000;
                break;
            case 'm':
                outputDistance = meters;
                break;
            case 'cm':
                outputDistance = meters / 0.01;
                break;
            case 'mm':
                outputDistance = meters / 0.001;
                break;
            case 'mi':
                outputDistance = meters / 1609.34;
                break;
            case 'yrd':
                outputDistance = meters / 0.9144;
                break;
            case 'ft':
                outputDistance = meters / 0.3048;
                break;
            case 'in':
                outputDistance = meters / 0.0254;
                break;
        }

        document.getElementById('outputDistance').value = outputDistance;
    });
}
