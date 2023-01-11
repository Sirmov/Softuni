import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const homeTemplate = (eventsPromise) =>
    html`<section class="welcomePage">
        <div id="welcomeMessage">
            <h1>My Theater</h1>
            <p>
                Since 1962 World Theatre Day has been celebrated by ITI Centres, ITI Cooperating Members, theatre
                professionals, theatre organizations, theatre universities and theatre lovers all over the world on the
                27th of March. This day is a celebration for those who can see the value and importance of the art form
                “theatre”, and acts as a wake-up-call for governments, politicians and institutions which have not yet
                recognised its value to the people and to the individual and have not yet realised its potential for
                economic growth.
            </p>
        </div>
        <div id="events">
            <h1>Future Events</h1>
            <div class="theaters-container">${until(eventsPromise, spinner)}</div>
        </div>
    </section>`;

export const eventsTemplate = (events) =>
    html`${events.length > 0
        ? html`<!--Created Events-->
              ${repeat(
                  events,
                  (event) => event._id,
                  (event, index) => eventTemplate(event)
              )}`
        : html`<!--No Theaters-->
              <h4 class="no-event">No Events Yet...</h4>`}`;

const eventTemplate = (event) =>
    html`<div class="eventsInfo">
        <div class="home-image">
            <img src=${event.imageUrl} />
        </div>
        <div class="info">
            <h4 class="title">${event.title}</h4>
            <h6 class="date">${event.date}</h6>
            <h6 class="author">${event.author}</h6>
            <div class="info-buttons">
                <a class="btn-details" href="/details/${event._id}">Details</a>
            </div>
        </div>
    </div>`;
