function attachEvents() {
    let submitBtn = document.getElementById('submit');
    let forecastDiv = document.getElementById('forecast');

    submitBtn.addEventListener('click', async (e) => {
        try {
            let locationInput = document.getElementById('location').value;
            let locations = await getForecastLocations();
            let location = locations.find(x => x.name === locationInput);

            if (!location) {
                throw new Error('Location not found');
            }

            let currentForecast = await getCurrentForecast(location.code);
            let upcomingForecast = await getUpcomingForecast(location.code);

            forecastDiv.style.display = 'block';

            let currentForecastElement = document.createElement('div');
            currentForecastElement.classList.add('forecasts');
            currentForecastElement.innerHTML =
                `<span class="condition symbol">${conditionParse(currentForecast.forecast.condition)}</span>
            <span class="condition">
            <span class="forecast-data">${currentForecast.name}</span>
            <span class="forecast-data">${currentForecast.forecast.low}&#176/${currentForecast.forecast.high}&#176</span>
            <span class="forecast-data">${currentForecast.forecast.condition}</span>
            </span>`;
            document.getElementById('current').lastChild.replaceWith(currentForecastElement);

            let upcomingForecastElement = document.createElement('div');
            upcomingForecastElement.classList.add('forecast-info');
            upcomingForecastElement.innerHTML =
                `<span class="upcoming">
            <span class="symbol">${conditionParse(upcomingForecast.forecast[0].condition)}</span>
            <span class="forecast-data">${upcomingForecast.forecast[0].low}&#176/${upcomingForecast.forecast[0].high}&#176</span>
            <span class="forecast-data">${upcomingForecast.forecast[0].condition}</span>
            </span>
            <span class="upcoming">
            <span class="symbol">${conditionParse(upcomingForecast.forecast[1].condition)}</span>
            <span class="forecast-data">${upcomingForecast.forecast[1].low}&#176/${upcomingForecast.forecast[0].high}&#176</span>
            <span class="forecast-data">${upcomingForecast.forecast[1].condition}</span>
            </span>
            <span class="upcoming">
            <span class="symbol">${conditionParse(upcomingForecast.forecast[2].condition)}</span>
            <span class="forecast-data">${upcomingForecast.forecast[2].low}&#176/${upcomingForecast.forecast[0].high}&#176</span>
            <span class="forecast-data">${upcomingForecast.forecast[2].condition}</span>
            </span>`;
            document.getElementById('upcoming').lastChild.replaceWith(upcomingForecastElement);
        } catch (error) {
            forecastDiv.style.display = 'block';
            forecastDiv.innerHTML = `<p style="color: red;font-size:48px;">Error: ${error.message}</p>`;
            submitBtn.disabled = true;
        }
    });
}

function conditionParse(condition) {
    let symbol;

    switch (condition) {
        case 'Sunny':
            symbol = '&#x2600';
            break;
        case 'Partly sunny':
            symbol = '&#x26C5';
            break;
        case 'Overcast':
            symbol = '&#x2601';
            break;
        case 'Rain':
            symbol = '&#x2614';
            break;
        default:
            throw new Error('Invalid forecast condition');
            break;
    }

    return symbol;
}

async function getCurrentForecast(locationCode) {
    let response = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`);

    if (!response.ok) {
        throw new Error(`Server status code: ${response.status}`);
    }

    let data = await response.json();

    return data;
}

async function getUpcomingForecast(locationCode) {
    let response = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`);

    if (!response.ok) {
        throw new Error(`Server status code: ${response.status}`);
    }

    let data = await response.json();

    return data;
}

async function getForecastLocations() {
    let response = await fetch('http://localhost:3030/jsonstore/forecaster/locations');

    if (!response.ok) {
        throw new Error(`Server status code: ${response.status}`);
    }

    let data = await response.json();

    return data;
}

attachEvents();
