function solve() {
  let textAreaElement = document.getElementById('input');
  let output = document.getElementById('output');
  output.innerHTML = '';

  let sentences = textAreaElement.value.split('.').filter((x) => x.length > 0);

  while (sentences.length > 0) {
    let arr = [];

    for (let i = 0; i < 3; i++) {
      let sentence = sentences.shift();
      if (sentence) {
        arr.push(sentence);
      }
    }

    let paragraph = arr.join('. ') + '.';
    output.innerHTML += `<p>${paragraph}</p>`;
  }
}
