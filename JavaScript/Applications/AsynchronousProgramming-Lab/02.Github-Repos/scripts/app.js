function loadRepos() {
	let username = document.getElementById('username').value;
	let listElement = document.getElementById('repos');

	fetch(`https://api.github.com/users/${username}/repos`)
		.then(res => {
			if (!res.ok) {
				throw new Error(`${res.status} ${res.statusText}`);
			}

			return res.json();
		})
		.then(data => {
			listElement.innerHTML = '';

			data.forEach(repo => {
				let liElement = document.createElement('li');
				liElement.innerHTML =
					`<a href="${repo.html_url}">
						${repo.full_name}
					</a>`;
				listElement.appendChild(liElement);
			});
		})
		.catch(error => {
			listElement.innerHTML = '';
			let errorElement = document.createElement('li');
			errorElement.textContent = error.message;
			listElement.appendChild(errorElement);
		})
}
