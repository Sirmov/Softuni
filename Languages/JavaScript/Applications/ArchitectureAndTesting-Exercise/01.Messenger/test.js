const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

describe('Unit tests for messenger app', async function () {
    this.timeout(6000);
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

    it('Should load and show messages when refresh button is clicked', async () => {
        const data = {
            1: {
                author: 'Nikola',
                content: 'Hi!'
            },
            2: {
                author: 'Valentin',
                content: 'Hello there!'
            }
        };
        await page.route('**/jsonstore/messenger', (route, request) => {
            route.fulfill({
                body: JSON.stringify(data),
                status: 200,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                }
            });
        });
        await page.goto('http://127.0.0.1:5500/01.Messenger/index.html');
        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/messenger'),
            page.click('text=Refresh')
        ]);
        let messages = await page.inputValue('textarea#messages');
        expect(messages).to.contain('Nikola: Hi!').and.to.include('Valentin: Hello there!');
    });
});
