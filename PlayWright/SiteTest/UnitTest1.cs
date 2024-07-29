using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace SiteTest
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestInitialize]
        public async Task Initialize()
        {
            await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        }


        // https://playwright.dev/dotnet/docs/locators

        [TestMethod]
        [Description("isteðe baðlý olarak açýklama eklenebilir.")]
        public async Task PageTitleTest()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("OrangeHRM"));
        }

        [TestMethod]
        public async Task ImageVisibleTest()
        {
            await Expect(Page.GetByAltText("company-branding")).ToBeVisibleAsync();
            await Page.GetByPlaceholder("Username").FillAsync("Admin");
            await Page.GetByPlaceholder("Password").FillAsync("admin123");
            await Expect(Page.GetByText("Forgot your password?")).ToBeVisibleAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            Thread.Sleep(5000);
        }
    
    
    }
}