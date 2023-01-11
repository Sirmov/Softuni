import { lit } from '../lib.js';
import { loading } from '../utils.js';

export const loginTemplate = (loginSubmit) =>
    lit.html`<section id="login">
    <div class="container">
        <form id="login-form" @submit=${loginSubmit} action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`;
