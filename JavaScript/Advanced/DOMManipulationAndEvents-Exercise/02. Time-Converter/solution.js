function attachEventsListeners() {
    let convertButtonElements = Array.from(document.querySelectorAll('input[type="button"][value="Convert"]'));
    convertButtonElements.forEach(element => {
        element.addEventListener('click', (e) => {
            let type = e.currentTarget.id;
            let daysElement = document.getElementById('days');
            let hoursElement = document.getElementById('hours');
            let minutesElement = document.getElementById('minutes');
            let secondsElement = document.getElementById('seconds');

            if (type === 'daysBtn') {
                let seconds = daysElement.value * 86400;
                let minutes = seconds / 60;
                let hours = seconds / 3600;

                hoursElement.value = hours;
                minutesElement.value = minutes;
                secondsElement.value = seconds;
            } else if (type === 'hoursBtn') {
                let seconds = hoursElement.value * 3600;
                let minutes = seconds / 60;
                let days = seconds / 86400;

                secondsElement.value = seconds;
                minutesElement.value = minutes;
                daysElement.value = days;
            } else if (type === 'minutesBtn') {
                let seconds = minutesElement.value * 60;
                let hours = seconds / 3600;
                let days = seconds / 86400;

                secondsElement.value = seconds;
                hoursElement.value = hours;
                daysElement.value = days;
            } else if (type === 'secondsBtn') {
                let seconds = secondsElement.value;
                let minutes = seconds / 60;
                let hours = seconds / 3600;
                let days = seconds / 86400;

                minutesElement.value = minutes;
                hoursElement.value = hours;
                daysElement.value = days;
            }
        })
    })
}
