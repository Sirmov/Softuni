function getArticleGenerator(articles) {
    return function () {
        if (articles.length > 0) {
            let articleElement = document.createElement('article');
            articleElement.textContent = articles.shift();
            document.querySelector('div#content').appendChild(articleElement);
        }
    }
}
