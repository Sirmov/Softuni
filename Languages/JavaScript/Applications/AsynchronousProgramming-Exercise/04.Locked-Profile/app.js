async function lockedProfile() {
    try {
        let response = await fetch('http://localhost:3030/jsonstore/advanced/profiles');

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();

        Object.entries(data).forEach(([k, v], i) => {
            let cardElement = document.createElement('div');
            cardElement.classList.add('profile');
            cardElement.innerHTML =
                `<img src="./iconProfile2.png" class="userIcon" />
                <label>Lock</label>
                <input type="radio" name="user${i}Locked" value="lock" checked>
                <label>Unlock</label>
                <input type="radio" name="user${i}Locked" value="unlock"><br>
                <hr>
                <label>Username</label>
                <input type="text" name="user${i}Username" value="${v.username}" disabled readonly />
                <div id="user${i}HiddenFields" class="hiddenInfo">
                    <hr>
                    <label>Email:</label>
                    <input type="email" name="user${i}Email" value="${v.email}" disabled readonly />
                    <label>Age:</label>
                    <input type="email" name="user${i}Age" value="${v.age}" disabled readonly />
                </div>
    
                <button onclick="showMoreOnClick(event)">Show more</button>`;
            document.getElementById('main').appendChild(cardElement);
        });
    } catch (error) {
        console.log(error);
    }
}

function showMoreOnClick(e) {
    let profile = e.currentTarget.parentNode;
    let isLocked = profile.querySelector('input[value="lock"]').checked;
    let hiddenInformationElement = profile.querySelector('div[id$=HiddenFields]');

    if (!isLocked) {
        hiddenInformationElement.classList.toggle('hiddenInfo');

        if (e.currentTarget.textContent === 'Show more') {
            e.currentTarget.textContent = 'Hide it';
        } else if (e.currentTarget.textContent === 'Hide it') {
            e.currentTarget.textContent = 'Show more';
        }
    }
}
