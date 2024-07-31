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
        await Expect(Page).ToHaveTitleAsync(new Regex("STORE"));        //b�yle bir site headeri var m� ? 
        await Expect(Page).ToHaveURLAsync("https://demoblaze.com/");     //b�yle bir URL link var m� ?
    }

    [TestMethod("LoginTest")]
    [Description("Login proccess testing")]
    public async Task canLogin()
    {//<a class="nav-link" href="#" id="login2" data-toggle="modal" data-target="#logInModal" style="display: block;">Log in</a>       
        //=> burada login butonuna tag� ile eri�me

        await Page.ClickAsync("//a[text()='Log in']");
        //=> tagi verilen butona t�kla testi.


        //await Page.Locator("//a[text()='Log in']").ClickAsync();      
        //=> bu da ayn� clck i�lemini yapar ama locator ile �nce konumu al�r sonra o konuma t�klar.

        await Page.FillAsync("#loginusername","test43@gmail.com");    
        //=> burada css ile id si loginusername olan alan� verilen de�er ile doldur dedik.

        await Page.Locator("[id='loginpassword']").FillAsync("123456");
        //=> burada id si loginusername olan alan� verilen de�er ile doldur dedik.

        //ister �nce locator ekle sonra fill de istersen de direkt fill ile parametreleri g�nder. �htiyaca g�re g�ncellenir.

        //�imdi s�rada parametreleri doldurduktan sonra logine basma i�lemi var.

        //<button type="button" onclick="logIn()" class="btn btn-primary">Log in</button>

        await Page.Locator("button[class='btn btn-primary']").Nth(2).ClickAsync();
        //Sitede bu class a ait 3 tane buton var. Nth ile indexleme yap�p 2 yi ald�k.

        Thread.Sleep(2500);     //=> giri� yap�p yapmad���n� g�rmek i�in

        await Expect(Page.Locator("//a[@id='logout2']")).ToBeVisibleAsync();
        //Bu elementin g�r�n�r oldu�unu do�rular (giri� yaparsak ��k�� yap bnutonu g�z�k�r.)

        //Text d���nda parametre verirsek @ ile
        // //a[@id='logout2']
       
    }

}