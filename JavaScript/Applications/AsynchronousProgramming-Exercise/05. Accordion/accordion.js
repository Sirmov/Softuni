async function solution() {
    try {
        const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();

        data.forEach(element => {
            let articleElement = document.createElement('div');
            articleElement.classList.add('accordion');
            articleElement.innerHTML =
                `<div class="head">
                    <span>${element.title}</span>
                    <button class="button" id="${element._id}" onclick="moreOnclick(event)">More</button>
                </div>
                <div class="extra"></div>`;
            document.getElementById('main').appendChild(articleElement);
        });
    } catch (error) {
        console.log(error);
    }
}

async function moreOnclick(e) {
    try {
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${e.currentTarget.id}`;
        const currentTarget = e.currentTarget;
        const parent = e.currentTarget.parentNode.parentNode;
        const extraDiv = parent.querySelector('div.extra');

        let response = await fetch(url);

        if (!response.ok) {
            throw new Error();
        }

        let data = await response.json();

        extraDiv.innerHTML = `<p>${data.content}</p>`;

        if (currentTarget.textContent === 'More') {
            currentTarget.textContent = 'Less';
            extraDiv.style.display = 'block';
        } else {
            currentTarget.textContent = 'More';
            extraDiv.style.display = 'none';
        }
    } catch (error) {
        console.log(error);
    }
}

solution();
