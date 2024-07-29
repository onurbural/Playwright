using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests
{
    public class SelectPage
    {
        private readonly IPage _page;
        private readonly ILocator selectBtn;
        private readonly ILocator continuteBtn;

        public SelectPage(IPage page)
        {
            _page = page;
            this.selectBtn = _page.Locator("#radiobutton_2");
            this.continuteBtn = _page.Locator("#continue");
        }

        public async Task SelectHotel()
        {
            await selectBtn.ClickAsync();
            await continuteBtn.ClickAsync();
        }
    }
}
