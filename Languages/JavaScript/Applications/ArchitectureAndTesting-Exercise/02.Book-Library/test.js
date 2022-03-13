const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

describe('Unit tests for messenger app', async function () {
    this.timeout(6000);
    // Change host if necessary
    const host = 'http://127.0.0.1:5500/01.Messenger/index.html';
    let browser, page;

    before(async () => {
        browser = await chromium.launch();
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
        await page.goto(host);
        await page.click('text=load all books');
    });

    it('', async () => {
    });
});
