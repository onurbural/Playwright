using Microsoft.Playwright;

public class SelectPage
{
    private readonly IPage _page;
    private readonly ILocator selectBtn;
    private readonly ILocator continuteBtn;

    public SelectPage(IPage page)
    {
        _page = page;
        this.selectBtn = _page.Locator("#radiobutton_0");
        this.continuteBtn = _page.Locator("#continue");
    }

    public async Task SelectHotel()
    {
        await selectBtn.ClickAsync();
        await continuteBtn.ClickAsync();
    }
}