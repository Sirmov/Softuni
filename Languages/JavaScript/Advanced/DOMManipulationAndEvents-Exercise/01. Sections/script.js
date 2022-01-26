function create(words) {
   let contentElement = document.getElementById('content');

   for (const element of words) {
      let parentDiv = document.createElement('div');
      console.log(element);

      let paragraph = document.createElement('p');
      paragraph.textContent = element;
      paragraph.style.display = 'none';

      parentDiv.appendChild(paragraph);

      parentDiv.addEventListener('click', (e) => {
         e.currentTarget.firstChild.style.display = 'block';
      });

      contentElement.appendChild(parentDiv);
   }
}
