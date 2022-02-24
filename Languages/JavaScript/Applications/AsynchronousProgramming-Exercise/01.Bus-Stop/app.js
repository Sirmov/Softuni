async function getInfo() {
    let stopId = document.getElementById('stopId').value;
    let busesListElement = document.getElementById('buses');
    busesListElement.innerHTML = '';

    try {
        let response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);

        if (!response.ok) {
            let error = new Error();
            error.status = response.status;
            error.statusText = response.statusText;
            throw error;
        }

        let data = await response.json();

        document.getElementById('stopName').textContent = data.name;
        Object.entries(data.buses).forEach(([busId, time]) => {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${busId} arrives in ${time} minutes`;
            busesListElement.appendChild(liElement);
        });
    } catch (error) {
        document.getElementById('stopName').textContent = 'Error';
        console.log(error);
    }
}
