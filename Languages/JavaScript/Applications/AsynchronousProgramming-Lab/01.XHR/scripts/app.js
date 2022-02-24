function loadRepos() {
   let request = new XMLHttpRequest();

   request.onreadystatechange = function () {
      if (request.readyState === 4 && request.status === 200) {
         document.getElementById('res').textContent = request.response;
      }
   }

   request.open('GET', 'https://api.github.com/users/testnakov/repos');
   request.send();
}
