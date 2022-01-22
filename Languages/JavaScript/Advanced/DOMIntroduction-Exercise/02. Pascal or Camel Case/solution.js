function solve() {
  let textElement = document.getElementById('text');
  let namingConventionElement = document.getElementById('naming-convention');

  let words = textElement.value
    .split(' ')
    .filter(x => x.length > 0)
    .map(x => x.split('').map(char => char.toLowerCase()))
    .map(x => x.join(''));
  let namingConvention = namingConventionElement.value;
  let result = '';

  if (namingConvention === 'Camel Case') {
    result = words.shift();
    words.forEach(element => {
      let characters = element.split('');
      characters[0] = characters[0].toUpperCase();
      let word = characters.join('');
      result += word;
    });
  } else if (namingConvention === 'Pascal Case') {
    words.forEach(element => {
      let characters = element.split('');
      characters[0] = characters[0].toUpperCase();
      let word = characters.join('');
      console.log(word);
      result += word;
    });
  } else {
    result = 'Error!';
  }

  let resultElement = document.getElementById('result');
  resultElement.textContent = result;
}
