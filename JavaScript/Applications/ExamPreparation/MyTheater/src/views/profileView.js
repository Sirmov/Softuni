import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const profileTemplate = (userEmail, eventsPromise) =>
    html`<section id="profilePage">
        <div class="userInfo">
            <div class="avatar">
                <img src="./images/profilePic.png" />
            </div>
            <h2>${userEmail}</h2>
        </div>
        <div class="board">${until(eventsPromise, spinner)}</div>
    </section>`;

export const eventsTemplate = (events) =>
    html`${events.length > 0
        ? html`<!--If there are event-->
              ${repeat(
                  events,
                  (event) => event._id,
                  (event, index) => eventTemplate(event)
              )}`
        : html`<!--If there are no event-->
              <div class="no-events">
                  <p>This user has no events yet!</p>
              </div>`}`;

const eventTemplate = (event) =>
    html`<div class="eventBoard">
        <div class="event-info">
            <img src=${event.imageUrl} />
            <h2>${event.title}</h2>
            <h6>${event.date}</h6>
            <a href="/details/${event._id}" class="details-button">Details</a>
        </div>
    </div>`;
