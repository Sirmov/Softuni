window.onload = loadRecipes;

async function loadRecipes() {
    try {
        let mainElement = document.querySelector('main');
        let response = await fetch('http://localhost:3030/jsonstore/cookbook/recipes');

        if (!response.ok) {
            let error = new Error();
            error.responseStatus = response.status;
            error.responseStatusText = response.statusText;
            throw error;
        }

        let data = await response.json();
        mainElement.innerHTML = '';

        Object.entries(data).forEach(([key, value]) => {
            let articleElement = document.createElement('article');
            articleElement.classList.add('preview');
            articleElement.addEventListener('click', recipeOnClick.bind(null, value._id))
            articleElement.innerHTML =
                `<div class="title">
                        <h2>${value.name}</h2>
                    </div>
                    <div class="small">
                        <img src="${value.img}">
                    </div>`;
            mainElement.appendChild(articleElement);
        });
    } catch (error) {
        console.log(error);
    }
}

async function recipeOnClick(id, e) {
    let articleElement = e.currentTarget;
    let recipeDescription = await getRecipeDescription(id);
    if (articleElement.classList.toggle('preview')) {
        articleElement.innerHTML =
            `<div class="title">
                <h2>${recipeDescription.name}</h2>
            </div>
            <div class="small">
                <img src="${recipeDescription.img}">
            </div>`;
    } else {
        articleElement.innerHTML =
            `<h2>${recipeDescription.name}</h2>
            <div class="band">
                <div class="thumb">
                    <img src="${recipeDescription.img}">
                </div>
                <div class="ingredients">
                    <h3>Ingredients:</h3>
                    <ul>
                        ${recipeDescription.ingredients.map(x => `<li>${x}</li>`).join('\n')}
                    </ul>
                </div>
            </div>
            <div class="description">
                <h3>Preparation:</h3>
                ${recipeDescription.steps.map(x => `<p>${x}</p>`).join('\n')}
            </div>`;
    }
}

async function getRecipeDescription(id) {
    try {
        let response = await fetch(`http://localhost:3030/jsonstore/cookbook/details/${id}`);

        if (!response.ok) {
            let error = new Error();
            error.responseStatus = response.status;
            error.responseStatusText = response.statusText;
            throw error;
        }

        let data = await response.json();

        return data;
    } catch (error) {
        console.log(error);
    }
}
