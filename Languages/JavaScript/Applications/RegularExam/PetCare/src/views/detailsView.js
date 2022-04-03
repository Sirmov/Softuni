import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const detailsTemplate = (petPromise) =>
    html`<!--Details Page-->
        <section id="detailsPage">
            <div class="details">${until(petPromise, nothing)}</div>
        </section>`;

export const petTemplate = (pet, donations, onDelete, onDonate) =>
    html`<div class="animalPic">
            <img src=${pet.image} />
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${donations * 100}$</h4>
            </div>

            ${pet.isLogged
                ? html`<!-- if there is no registered user, do not display div-->
                      <div class="actionBtn">
                          ${pet.isOwner
                              ? html`<!-- Only for registered user and creator of the pets-->
                                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                                    <a href="javascript:void(0)" @click=${onDelete} class="remove">Delete</a>`
                              : !pet.hasDonated
                              ? html`<!--(Bonus Part) Only for no creator and user-->
                                    <a href="javascript:void(0)" @click=${onDonate} class="donate">Donate</a>`
                              : nothing}
                      </div>`
                : nothing}
        </div>`;
