function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchBoxElement = document.getElementById('searchField');
      let search = searchBoxElement.value;
      searchBoxElement.value = '';
      let tableRowElements = Array.from(document.querySelectorAll('tbody > tr'));

      tableRowElements.forEach(x => x.classList.remove('select'));

      tableRowElements.forEach(element => {
         let rowData = Array.from(element.children);
         if (rowData.some(x => x.textContent.includes(search))) {
            element.classList.add('select');
         }
      })
   }
}
