using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    public class BookingPage
    {
        private readonly IPage _page;
        private readonly ILocator firstName;
        private readonly ILocator lastName;
        private readonly ILocator billingAddress;
        private readonly ILocator creaditCardNumber;
        private readonly ILocator creditCardType;
        private readonly ILocator expiryDateMonth;
        private readonly ILocator expiryDateYear;
        private readonly ILocator cvvNumber;
        private readonly ILocator bookNowBtn;
        private readonly ILocator process_span;

        public BookingPage(IPage page)
        {
            _page = page;
            firstName = _page.Locator("#first_name");
            lastName = _page.Locator("#last_name");
            billingAddress = _page.Locator("#address");
            creaditCardNumber = _page.Locator("#cc_num");
            creditCardType = _page.Locator("#cc_type");
            expiryDateMonth = _page.Locator("#cc_exp_month");
            expiryDateYear = _page.Locator("#cc_exp_year");
            cvvNumber = _page.Locator("#cc_cvv");
            bookNowBtn = _page.Locator("#book_now");
            process_span = page.Locator("#process_span");

        }


        public async Task BookHotel(string fName, string lName, string billingAdr, string cCardNumber, string cCardType, string expiryDateM, string expiryDateY, string cvvNum)
        {

            await firstName.FillAsync(fName);
            await lastName.FillAsync(lName);
            await billingAddress.FillAsync(billingAdr);
            await creaditCardNumber.FillAsync(cCardNumber);
            await creditCardType.TypeAsync(cCardType);
            await expiryDateMonth.TypeAsync(expiryDateM);
            await expiryDateYear.TypeAsync(expiryDateY);
            await cvvNumber.TypeAsync(cvvNum);
            
            await bookNowBtn.ClickAsync();

            Thread.Sleep(10000);


        }
    }
}
