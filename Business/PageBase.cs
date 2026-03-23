namespace Business;

using Core.WebDriver;

public abstract class PageBase
{
    protected WebDriverWrapper WebDriverWrapper { get; } = WebDriverWrapper.GetInstance();
}
