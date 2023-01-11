import { html } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const registerTemplate = (registerSubmit) =>
    html`<section id="registerPage" @submit=${registerSubmit}>
        <form>
            <fieldset>
                <legend>Register</legend>

                <label for="email" class="vhide">Email</label>
                <input id="email" class="email" name="email" type="text" placeholder="Email" />

                <label for="password" class="vhide">Password</label>
                <input id="password" class="password" name="password" type="password" placeholder="Password" />

                <label for="conf-pass" class="vhide">Confirm Password:</label>
                <input
                    id="conf-pass"
                    class="conf-pass"
                    name="conf-pass"
                    type="password"
                    placeholder="Confirm Password"
                />

                <button type="submit" class="register">Register</button>

                <p class="field">
                    <span>If you already have profile click <a href="/login">here</a></span>
                </p>
            </fieldset>
        </form>
    </section>`;
