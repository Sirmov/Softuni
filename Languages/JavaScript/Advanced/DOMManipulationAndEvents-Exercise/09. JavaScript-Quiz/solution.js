function solve() {
  let rightAnswers = 0;

  let sectionElements = Array.from(document.querySelectorAll('div#quizzie section'));
  let answerElements = document.querySelectorAll('div#quizzie section li.quiz-answer');

  for (const element of answerElements) {
    element.addEventListener('click', (e) => {
      let answer = element.getElementsByTagName('p')[0].textContent;

      if (answer === 'onclick' ||
        answer === 'JSON.stringify()' ||
        answer === 'A programming API for HTML and XML documents') {
        rightAnswers++;
      }

      let currentSection = sectionElements.shift();
      currentSection.style.display = 'none';

      if (sectionElements.length > 0) {
        sectionElements[0].style.display = 'block';
      } else {
        let output = rightAnswers === 3 ? 'You are recognized as top JavaScript fan!' : `You have ${rightAnswers} right answers`;
        document.getElementById('results').querySelector('h1').textContent = output;
        document.getElementById('results').style.display = 'block';
      }
    });
  }
}
