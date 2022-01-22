function search() {
   let listElements = document.querySelectorAll('ul#towns > li');
   let searchBoxElement = document.getElementById('searchText');

   let search = searchBoxElement.value;
   let matches = 0;

   Array.from(listElements).forEach(element => {
      if (element.textContent.includes(search)) {
         element.style.fontWeight = 'bold';
         element.style.textDecoration = 'underline';
         matches++;
      } else {
         element.style.fontWeight = 'normal';
         element.style.textDecoration = 'none';
      }
   })

   document.getElementById('result').textContent = `${matches} matches found`;
}
