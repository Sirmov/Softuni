class ContactInfoBoxElement {
    #online;
    #element;

    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.#online = false;
        this.#element = null;
    }

    get online() {
        return this.#online;
    }

    set online(value) {
        this.#online = value;

        if (this.#element) {
            if (value) {
                this.#element.getElementsByClassName('title')[0].classList.add('online');
            } else {
                this.#element.getElementsByClassName('title')[0].classList.remove('online');
            }
        }
    }

    render(id) {
        let contactInfoCard = document.createElement('article');
        contactInfoCard.innerHTML = `
        <div class="title${this.online ? ' online' : ''}">${this.firstName} ${this.lastName}<button>&#8505;</button></div>
        <div class="info">
            <span>&phone; ${this.phone}</span>
            <span>&#9993; ${this.email}</span>
        </div>`;

        contactInfoCard.getElementsByClassName('info')[0].style.display = 'none';
        contactInfoCard.getElementsByTagName('button')[0].addEventListener('click', (e) => {
            let parent = e.currentTarget.parentElement.parentElement;
            let infoElement = parent.getElementsByClassName('info')[0];

            if (infoElement.style.display == 'none') {
                infoElement.style.display = 'block';
            } else {
                infoElement.style.display = 'none';
            }
        });

        this.#element = contactInfoCard;
        document.getElementById(id).appendChild(contactInfoCard);
    }
}
