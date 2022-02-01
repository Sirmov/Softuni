function solve() {
    let taskInputElement = document.getElementById('task');
    let descriptionInputElement = document.getElementById('description');
    let dueDateInputElement = document.getElementById('date');

    let sections = document.querySelectorAll('div.wrapper section');
    let openSectionDivElement = sections[1].querySelector('div:nth-of-type(2)');
    let inProgressSectionDivElement = sections[2].querySelector('div:nth-of-type(2)');
    let completeSectionDivElement = sections[3].querySelector('div:nth-of-type(2)');

    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let task = taskInputElement.value;
        let description = descriptionInputElement.value;
        let dueDate = dueDateInputElement.value;

        if (task && description && dueDate) {
            let taskArticle = createOpenTask(task, description, dueDate);
            openSectionDivElement.appendChild(taskArticle);
        }
    });

    function createOpenTask(task, description, dueDate) {
        let articleElement = createDefaultArticle(task, description, dueDate);

        let divElement = document.createElement('div');
        divElement.classList.add('flex');

        let startBtn = document.createElement('button');
        startBtn.classList.add('green');
        startBtn.textContent = 'Start';
        startBtn.addEventListener('click', (e) => {
            let inProgressTask = e.currentTarget.parentElement.parentElement;
            e.currentTarget.parentElement.remove();

            let divElement = document.createElement('div');
            divElement.classList.add('flex');

            let finishBtn = document.createElement('button');
            finishBtn.classList.add('orange');
            finishBtn.textContent = 'Finish';
            finishBtn.addEventListener('click', (e) => {
                let completedTask = e.currentTarget.parentElement.parentElement;
                e.currentTarget.parentElement.remove();

                completeSectionDivElement.appendChild(completedTask);
            });

            divElement.appendChild(createDeleteButton());
            divElement.appendChild(finishBtn);

            inProgressTask.appendChild(divElement);
            inProgressSectionDivElement.appendChild(inProgressTask);
        });

        divElement.appendChild(startBtn);
        divElement.appendChild(createDeleteButton());

        articleElement.appendChild(divElement);
        return articleElement;
    }

    function createDeleteButton() {
        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', (e) => {
            e.currentTarget.parentElement.parentElement.remove();
        });

        return deleteBtn;
    }

    function createDefaultArticle(task, description, dueDate) {
        let articleElement = document.createElement('article');
        let titleElement = document.createElement('h3');
        let descriptionElement = document.createElement('p');
        let dueDateElement = document.createElement('p');

        titleElement.textContent = task;
        descriptionElement.textContent = `Description: ${description}`;
        dueDateElement.textContent = `Due Date: ${dueDate}`;

        articleElement.appendChild(titleElement);
        articleElement.appendChild(descriptionElement);
        articleElement.appendChild(dueDateElement);
        return articleElement;
    }
}
