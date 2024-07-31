using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator userNameTxt;
        private readonly ILocator passwordTxt;
        private readonly ILocator loginBtn;

        public LoginPage(IPage page)
        {
            _page = page;
            userNameTxt = _page.Locator("#username");
            passwordTxt = _page.Locator("#password");
            loginBtn = _page.Locator("input[type='Submit'][name='login'][id='login'][class='login_button'][value='Login']");
            //<input type="Submit" name="login" id="login" class="login_button" value="Login">

        }

        public async Task LoginTest(string userName, string password, string url)
        {
            await _page.GotoAsync(url);
            await userNameTxt.FillAsync(userName);
            await passwordTxt.FillAsync(password);
            await loginBtn.ClickAsync();

        }
    }
}
