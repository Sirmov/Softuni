import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const dashboardTemplate = (petsPromise) =>
    html`<!--Dashboard-->
        <section id="dashboard">
            <h2 class="dashboard-title">Services for every animal</h2>
            <div class="animals-dashboard">${until(petsPromise, nothing)}</div>
        </section>`;

export const petsTemplate = (pets) =>
    html`${pets.length > 0
        ? html`${repeat(
              pets,
              (pet) => pet._id,
              (pet, index) => petTemplate(pet)
          )}`
        : html`<!--If there is no pets in dashboard-->
              <div>
                  <p class="no-pets">No pets in dashboard</p>
              </div>`}`;

const petTemplate = (pet) =>
    html`<div class="animals-board">
        <article class="service-img">
            <img class="animal-image-cover" src=${pet.image} />
        </article>
        <h2 class="name">${pet.name}</h2>
        <h3 class="breed">${pet.breed}</h3>
        <div class="action">
            <a class="btn" href="/details/${pet._id}">Details</a>
        </div>
    </div>`;
