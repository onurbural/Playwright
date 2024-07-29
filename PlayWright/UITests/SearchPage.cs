using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    public class SearchPage
    {
        private readonly IPage _page;
        private readonly ILocator locationDd;
        private readonly ILocator hotelsDd;
        private readonly ILocator roomTypeDd;
        private readonly ILocator numberOfRoomsDd;
        private readonly ILocator dateAdultsPerRoomDd;
        private readonly ILocator childrenPerRoomDd;
        private readonly ILocator checkInDatetext;
        private readonly ILocator cheakOutDatetext;
        private readonly ILocator searchBtn;

        public SearchPage(IPage page)
        {
            _page = page;
            this.locationDd = _page.Locator("#location");
            this.hotelsDd = _page.Locator("#hotels");
            this.roomTypeDd = _page.Locator("#room_type");
            this.numberOfRoomsDd = _page.Locator("#room_nos");
            this.dateAdultsPerRoomDd = _page.Locator("#adult_room");
            this.childrenPerRoomDd = _page.Locator("#child_room");
            this.checkInDatetext = _page.Locator("#datepick_in");
            this.cheakOutDatetext = _page.Locator("#datepick_out");
            this.searchBtn = _page.Locator("#Submit");
        }

        public async Task SearchHotel(string location)
        {
           
            await locationDd.TypeAsync(location);
            await searchBtn.ClickAsync();

           
        }
    }
}
