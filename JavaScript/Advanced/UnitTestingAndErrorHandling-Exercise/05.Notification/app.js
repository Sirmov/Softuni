function notify(message) {
  let divElement = document.getElementById('notification');
  divElement.addEventListener('click', (e) => {
    e.currentTarget.style.display = 'none';
  });
  divElement.textContent = message;
  divElement.style.display = 'block';
}
