using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{

    [TestInitialize]
    public async Task Initialize()
    {
        await Page.GotoAsync("https://demoblaze.com/");
    }

    [TestMethod("Test")]
    [Description("asdasfasdasaasdasdasdasdasdasdasd")]
    public async Task HasTitle()
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("STORE"));        //böyle bir site headeri var mý ? 
        await Expect(Page).ToHaveURLAsync("https://demoblaze.com/");     //böyle bir URL link var mý ?
    }

    [TestMethod("LoginTest")]
    [Description("Login proccess testing")]
    public async Task canLogin()
    {//<a class="nav-link" href="#" id="login2" data-toggle="modal" data-target="#logInModal" style="display: block;">Log in</a>       
        //=> burada login butonuna tagý ile eriþme

        await Page.ClickAsync("//a[text()='Log in']");
        //=> tagi verilen butona týkla testi.


        //await Page.Locator("//a[text()='Log in']").ClickAsync();      
        //=> bu da ayný clck iþlemini yapar ama locator ile önce konumu alýr sonra o konuma týklar.

        await Page.FillAsync("#loginusername","test43@gmail.com");    
        //=> burada css ile id si loginusername olan alaný verilen deðer ile doldur dedik.

        await Page.Locator("[id='loginpassword']").FillAsync("123456");
        //=> burada id si loginusername olan alaný verilen deðer ile doldur dedik.

        //ister önce locator ekle sonra fill de istersen de direkt fill ile parametreleri gönder. Ýhtiyaca göre güncellenir.

        //Þimdi sýrada parametreleri doldurduktan sonra logine basma iþlemi var.

        //<button type="button" onclick="logIn()" class="btn btn-primary">Log in</button>

        await Page.Locator("button[class='btn btn-primary']").Nth(2).ClickAsync();
        //Sitede bu class a ait 3 tane buton var. Nth ile indexleme yapýp 2 yi aldýk.

        Thread.Sleep(2500);     //=> giriþ yapýp yapmadýðýný görmek için

        await Expect(Page.Locator("//a[@id='logout2']")).ToBeVisibleAsync();
        //Bu elementin görünür olduðunu doðrular (giriþ yaparsak çýkýþ yap bnutonu gözükür.)

        //Text dýþýnda parametre verirsek @ ile
        // //a[@id='logout2']
       
    }

}