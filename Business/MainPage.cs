namespace Business;

using Core;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

public sealed class MainPage
    : PageBase
{
    private static readonly By _menuButtonLocator = By.CssSelector("#react-burger-menu-btn");
    private static readonly By _swagLabsLabelLocator = By.CssSelector("div[class~='header_label'] div[class~='app_logo']");
    private static readonly By _shoppingCartIconLocator = By.CssSelector("#shopping_cart_container>a[class~='shopping_cart_link']");
    private static readonly By _sortingDropdownLocator = By.CssSelector("select[class~='product_sort_container']");
    private static readonly By _inventoryListLocator = By.CssSelector("#inventory_container>div[class~='inventory_list']");

    private static readonly IReadOnlyList<By> ValidationLocators =
    [
        _menuButtonLocator,
        _swagLabsLabelLocator,
        _shoppingCartIconLocator,
        _sortingDropdownLocator,
        _inventoryListLocator
    ];

    internal MainPage()
    {
        FlowLogger.Logger.LogInformation("Main page loaded. Current URL: \"{Url}\".", WebDriverWrapper.GetUrl());
    }

    public bool IsLoadedCorrectly()
    {
        foreach (var locator in ValidationLocators)
        {
            if (!WebDriverWrapper.DoesElementExist(locator))
            {
                FlowLogger.Logger.LogInformation("Element with the locator \"{By}\" could not be located.", locator);
                return false;
            }

            FlowLogger.Logger.LogInformation("Element with the locator \"{By}\" has been successfully located.", locator);
        }

        FlowLogger.Logger.LogInformation("Main page loaded correctly. All elements verified.");
        return true;
    }
}
