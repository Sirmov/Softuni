function lockedProfile() {
    let showMoreBtnElements = document.querySelectorAll('div.profile button');

    for (const btn of showMoreBtnElements) {
        btn.addEventListener('click', (e) => {
            let profile = e.currentTarget.parentNode;
            let isLocked = profile.querySelector('input[value="lock"]').checked;
            let hiddenInformationElement = profile.querySelector('div[id$=HiddenFields]');


            if (!isLocked) {
                if (e.currentTarget.textContent === 'Show more') {
                    hiddenInformationElement.style.display = 'block';
                    e.currentTarget.textContent = 'Hide it';
                } else if (e.currentTarget.textContent === 'Hide it') {
                    hiddenInformationElement.style.display = 'none';
                    e.currentTarget.textContent = 'Show more';
                }
            }
        })
    }
}
