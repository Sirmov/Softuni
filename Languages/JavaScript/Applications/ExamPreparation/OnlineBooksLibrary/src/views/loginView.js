import { html, repeat, until, nothing } from '../utils/lib.js';
import { loading, spinner } from '../utils/dom.js';

export const loginTemplate = (loginSubmit) =>
    html`<section id="login-page" class="login">
        <form id="login-form" @submit=${loginSubmit} action="" method="">
            <fieldset>
                <legend>Login Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email" />
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password" />
                    </span>
                </p>
                <input class="button submit" type="submit" value="Login" />
            </fieldset>
        </form>
    </section>`;
