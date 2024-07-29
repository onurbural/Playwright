using Microsoft.Playwright.MSTest;
using PlaywrightTests;
using System.ComponentModel;

namespace UITests
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestInitialize]
        public async Task Initialize()
        {
            await Page.GotoAsync("https://adactinhotelapp.com/");           
        }

        [TestMethod]
        public async Task Login()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.LoginTest("honurbural", "123456", "https://adactinhotelapp.com/");
        }

        [TestMethod]
        [Category("SearchHotel")]
        public async Task SearchHotel()
        {
            LoginPage loginPage = new LoginPage(Page);
            SearchPage searchPage = new SearchPage(Page);

            await loginPage.LoginTest("honurbural", "123456", "https://adactinhotelapp.com/");
            await searchPage.SearchHotel("Sydney");
        }


        [TestMethod]
        [Category("SelectHotel")]
        public async Task SelectHotel()
        {
            LoginPage loginPage = new LoginPage(Page);
            SearchPage searchPage = new SearchPage(Page);
            SelectPage selectPage = new SelectPage(Page);

            await loginPage.LoginTest("honurbural", "123456", "https://adactinhotelapp.com/");
            await searchPage.SearchHotel("Sydney");
            await selectPage.SelectHotel();
        }

        [TestMethod]
        public async Task BookHotel()
        {
            LoginPage loginPage = new LoginPage(Page);
            SearchPage searchPage = new SearchPage(Page);
            SelectPage selectPage = new SelectPage(Page);
            BookingPage bookingPage = new BookingPage(Page);

            await loginPage.LoginTest("honurbural", "123456", "https://adactinhotelapp.com/");
            await searchPage.SearchHotel("Sydney");
            await selectPage.SelectHotel();

            await bookingPage.BookHotel("Onur", "BURAL", "123 Street", "1234567890123456", "VISA", "April", "2025", "123");
        }
    }
}