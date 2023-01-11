import { html, nothing, repeat, until } from './lib.js';
import { loading } from './utils.js';

export const navigationTemplate = (isLoggedIn) =>
    html`<h1><a href="/dashboard">Furniture Store</a></h1>
        <nav>
            <a id="catalogLink" href="/dashboard" class="active">Dashboard</a>
            ${isLoggedIn
                ? html`<div id="user">
                      <a id="createLink" href="/create-furniture">Create Furniture</a>
                      <a id="profileLink" href="/my-furniture">My Publications</a>
                      <a id="logoutBtn" href="/logout">Logout</a>
                  </div>`
                : html`<div id="guest">
                      <a id="loginLink" href="/login">Login</a>
                      <a id="registerLink" href="/register">Register</a>
                  </div>`}
        </nav>`;

export const dashboardTemplate = (furniturePromise, isMyFurniture) =>
    html`<div class="row space-top">
            <div class="col-md-12">
                ${isMyFurniture
                    ? html`<h1>My furniture</h1>
                          <p>This is a list of your publications.</p>`
                    : html`<h1>Welcome to Furniture System</h1>
                          <p>Select furniture from the catalog to view details.</p>`}
            </div>
        </div>
        <div class="row space-top">${until(furniturePromise, loading)}</div>`;

export const furnitureTemplate = (furniture) =>
    html` ${repeat(
        furniture,
        (furniture) => furniture._id,
        (furniture, index) => html`<div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src=${furniture.img} />
                    <p>${furniture.description}</p>
                    <footer>
                        <p>Price: <span>${furniture.price} $</span></p>
                    </footer>
                    <div>
                        <a href="/furniture/${furniture._id}" class="btn btn-info">Details</a>
                    </div>
                </div>
            </div>
        </div>`
    )}`;

export const createFurnitureTemplate = (createSubmit, error) =>
    html`<div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${createSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input
                            class="form-control${error ? (error.make ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-make"
                            type="text"
                            name="make"
                        />
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input
                            class="form-control${error ? (error.model ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-model"
                            type="text"
                            name="model"
                        />
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input
                            class="form-control${error ? (error.year ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-year"
                            type="number"
                            name="year"
                        />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input
                            class="form-control${error ? (error.description ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-description"
                            type="text"
                            name="description"
                        />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input
                            class="form-control${error ? (error.price ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-price"
                            type="number"
                            name="price"
                        />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input
                            class="form-control${error ? (error.img ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-image"
                            type="text"
                            name="img"
                        />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input
                            class="form-control${error ? (error.material ? ' is-invalid' : ' is-valid') : ''}"
                            id="new-material"
                            type="text"
                            name="material"
                        />
                    </div>
                    <input type="submit" class="btn btn-primary" value="Create" />
                </div>
            </div>
        </form>`;

export const detailsTemplate = (furniturePromise) =>
    html`<div class="row space-top">
        <div class="col-md-12">
            <h1>Furniture Details</h1>
        </div>
        ${until(furniturePromise, loading)}
    </div>`;

export const furnitureDetailsTemplate = (furniture, isOwner, editFurniture, deleteFurniture) =>
    html` <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src=${furniture.img} />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <p>Make: <span>${furniture.make}</span></p>
            <p>Model: <span>${furniture.model}</span></p>
            <p>Year: <span>${furniture.year}</span></p>
            <p>Description: <span>${furniture.description}</span></p>
            <p>Price: <span>${furniture.price}</span></p>
            <p>Material: <span>${furniture.material}</span></p>
            ${isOwner
                ? html`<div>
                      <a
                          data-id=${furniture._id}
                          @click=${editFurniture}
                          href="javascript:void(0)"
                          class="btn btn-info "
                          >Edit</a
                      >
                      <a
                          data-id=${furniture._id}
                          href="javascript:void(0)"
                          @click=${deleteFurniture}
                          class="btn btn-red"
                          >Delete</a
                      >
                  </div>`
                : nothing}
        </div>`;

export const editFurnitureTemplate = (formPromise) =>
    html`<div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        ${until(formPromise, loading)}`;

export const editFormTemplate = (furniture, editSubmit, error) =>
    html`<form data-id=${furniture._id} @submit=${editSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make">Make</label>
                    <input
                        class="form-control${error ? (error.make ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-make"
                        type="text"
                        name="make"
                        value=${furniture.make}
                    />
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model">Model</label>
                    <input
                        class="form-control${error ? (error.model ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-model"
                        type="text"
                        name="model"
                        value=${furniture.model}
                    />
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year">Year</label>
                    <input
                        class="form-control${error ? (error.year ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-year"
                        type="number"
                        name="year"
                        value=${furniture.year}
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description">Description</label>
                    <input
                        class="form-control${error ? (error.description ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-description"
                        type="text"
                        name="description"
                        value=${furniture.description}
                    />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price">Price</label>
                    <input
                        class="form-control${error ? (error.price ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-price"
                        type="number"
                        name="price"
                        value=${furniture.price}
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image">Image</label>
                    <input
                        class="form-control${error ? (error.img ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-image"
                        type="text"
                        name="img"
                        value=${furniture.img}
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material">Material (optional)</label>
                    <input
                        class="form-control${error ? (error.material ? ' is-invalid' : ' is-valid') : ''}"
                        id="new-material"
                        type="text"
                        name="material"
                        value=${furniture.material}
                    />
                </div>
                <input type="submit" class="btn btn-info" value="Edit" />
            </div>
        </div>
    </form>`;

export const loginTemplate = (loginSubmit) =>
    html`<div class="row space-top">
            <div class="col-md-12">
                <h1>Login User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${loginSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email" />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password" />
                    </div>
                    <input type="submit" class="btn btn-primary" value="Login" />
                </div>
            </div>
        </form>`;

export const registerTemplate = (registerSubmit) =>
    html`<div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${registerSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email" />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password" />
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass" />
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>`;
