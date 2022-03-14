const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

describe('Unit tests for book library app', async function () {
    this.timeout(6000);
    // Change host if necessary
    const host = 'http://127.0.0.1:5500/02.Book-Library/index.html';
    const debug = false;
    let browser, page;
    let options = {};
    if (debug) {
        options = { headless: false, slowMo: 1500 };
        this.timeout(20000);
    }

    const mockData = {
        1: { author: 'Nikola Sirmov', title: 'Programming in a nutshell' },
        2: { author: 'Svetlin Nakov', title: 'C# Fundamentals' }
    };

    async function mockGetBooksRequest(page) {
        page.route('**/jsonstore/collections/books', (route, request) => {
            route.fulfill({
                body: JSON.stringify(mockData),
                status: 200,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            });
        });
    }

    before(async () => {
        browser = await chromium.launch(options);
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    it('Should load and show all books when load books button is clicked', async () => {
        await mockGetBooksRequest(page);

        await page.goto(host);
        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/collections/books'),
            page.click('text=load all books')
        ]);
        let areVisible = [];
        areVisible.push(await page.isVisible(`text="${mockData[1].title}"`));
        areVisible.push(await page.isVisible(`text="${mockData[1].author}"`));
        areVisible.push(await page.isVisible(`text="${mockData[2].title}"`));
        areVisible.push(await page.isVisible(`text="${mockData[2].author}"`));

        expect(areVisible).to.satisfy((arr) => arr.every((x) => x));
    });

    it('Adding book form should not accept empty input fields', async () => {
        await page.goto(host);
        page.on('dialog', (dialog) => {
            expect(dialog.message()).to.equal('All fields are required!');
            dialog.accept();
        });
        await page.click('text=submit');
    });

    it('Add book should send request with correct data', async () => {
        const data = { title: 'Programming in a nutshell', author: 'Nikola Sirmov' };

        await page.goto(host);
        await page.fill('form#createForm input[name="title"]', data.title);
        await page.fill('form#createForm input[name="author"]', data.author);
        const [request] = await Promise.all([
            page.waitForRequest('**/jsonstore/collections/books'),
            page.click('form#createForm button')
        ]);
        const postData = JSON.parse(request.postData());

        expect(postData).to.deep.equal(data);
    });

    it('Should show the edit form when edit button is clicked', async () => {
        await mockGetBooksRequest(page);

        await page.goto(host);
        await page.click('text=load all books');
        await page.click('text=edit');
        const isVisible = await page.isVisible('text=edit form');

        expect(isVisible).to.be.true;
    });

    it('Should fill the input field with the edited book data', async () => {
        await mockGetBooksRequest(page);

        await page.route('**/jsonstore/collections/books/1', (route, request) => {
            route.fulfill({
                body: JSON.stringify(mockData[1]),
                status: 200,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            });
        });

        await page.goto(host);
        await page.click('text=load all books');
        await page.click('text=edit');
        const titleInputValue = await page.inputValue('form#editForm input[name="title"]');
        const authorInputValue = await page.inputValue('form#editForm input[name="author"]');

        expect(titleInputValue).to.equal(mockData[1].title);
        expect(authorInputValue).to.equal(mockData[1].author);
    });

    it('Should send correct data when save button is clicked', async () => {
        const data = { title: 'A new adventure', author: 'N. Sirmov' };
        await mockGetBooksRequest(page);

        await page.goto(host);
        await page.click('text=load all books');
        await page.click('text=edit');
        await page.fill('#editForm input[name="title"]', data.title);
        await page.fill('#editForm input[name="author"]', data.author);
        const [request] = await Promise.all([
            page.waitForRequest((request) => request.method() === 'PUT'),
            page.click('text=save')
        ]);
        const postData = JSON.parse(request.postData());

        expect(postData).to.deep.equal(data);
    });

    it('Should open a confirm dialog when delete button is clicked', async () => {
        await mockGetBooksRequest(page);

        await page.goto(host);
        await page.click('text=load all books');
        page.on('dialog', (dialog) => {
            expect(dialog.message()).to.equal('Are you sure you want to delete this book?');
            dialog.dismiss();
        });
        await page.click('text=delete');
    });

    it('Should send correct request when delete button is clicked', async () => {
        await mockGetBooksRequest(page);

        await page.goto(host);
        await page.click('text=load all books');
        page.on('dialog', (dialog) => dialog.accept());
        const [request] = await Promise.all([
            page.waitForRequest((request) => request.method() === 'DELETE'),
            page.click('text=delete')
        ]);
        
        expect(request.url().endsWith('/1')).to.be.true;
    });
});
