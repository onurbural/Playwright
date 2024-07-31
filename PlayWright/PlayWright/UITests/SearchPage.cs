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
            this.locationDd = _page.Locator("select[name='location'][id='location'][class='search_combobox']");
            // <select name="location" class="search_combobox" id="location">
            this.hotelsDd = _page.Locator("select[name='hotels'][id='hotels'][class='search_combobox']");
            //<select name="hotels" id="hotels" class="search_combobox">


            this.roomTypeDd = _page.Locator("select[name='room_type'][id='room_type'][class='search_combobox']");
            //<select name="room_type" id="room_type" class="search_combobox">



            this.numberOfRoomsDd = _page.Locator("#room_nos");
            this.dateAdultsPerRoomDd = _page.Locator("#adult_room");
            this.childrenPerRoomDd = _page.Locator("#child_room");
            this.checkInDatetext = _page.Locator("input[name='datepick_in'][type='text'][class='date_pick'][id='datepick_in']");
            //<input name="datepick_in" type="text" class="date_pick" id="datepick_in" value="31/07/2024" maxlength="10">


            this.cheakOutDatetext = _page.Locator("#datepick_out");
            this.searchBtn = _page.Locator("#Submit");
        }

        public async Task SearchHotel(string location, string hotels, string roomType, string checkInDate)
        {
           
            await locationDd.TypeAsync(location);
            await hotelsDd.TypeAsync(hotels);
            await roomTypeDd.TypeAsync(roomType);
            await checkInDatetext.FillAsync(checkInDate);

            await searchBtn.ClickAsync();

            Thread.Sleep(3500);
        }
    }
}
