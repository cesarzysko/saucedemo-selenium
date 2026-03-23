namespace Business;

using Core;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

public sealed class LoginPage
    : PageBase
{
    private static readonly By _usernameInputFieldLocator = By.CssSelector("#user-name");
    private static readonly By _passwordInputFieldLocator = By.CssSelector("#password");
    private static readonly By _loginButtonLocator = By.CssSelector("#login-button");
    private static readonly By _errorMsgLocator = By.CssSelector("div[class~='error-message-container']>h3");

    public LoginPage()
    {
        FlowLogger.Logger.LogInformation("Login page loaded. Current URL: \"{Url}\".", Config.Url);
        WebDriverWrapper.Open(Config.Url);
    }

    public LoginPage EnterUsername(string username)
    {
        FlowLogger.Logger.LogInformation("Entering \"{Username}\" to the Username field.", username);
        WebDriverWrapper.SetText(_usernameInputFieldLocator, username);
        return this;
    }

    public LoginPage ClearUsername()
    {
        FlowLogger.Logger.LogInformation("Clearing the Username field.");
        WebDriverWrapper.ClearText(_usernameInputFieldLocator);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        FlowLogger.Logger.LogInformation("Entering \"{Password}\" to the Password field.", password);
        WebDriverWrapper.SetText(_passwordInputFieldLocator, password);
        return this;
    }

    public LoginPage ClearPassword()
    {
        FlowLogger.Logger.LogInformation("Clearing the Password field.");
        WebDriverWrapper.ClearText(_passwordInputFieldLocator);
        return this;
    }

    public MainPage? ClickLoginButton()
    {
        FlowLogger.Logger.LogInformation("Clicking the Login button.");
        WebDriverWrapper.ClickElement(_loginButtonLocator);
        if (!IsErrorMessageVisible())
        {
            return new MainPage();
        }

        string errorMsg = GetErrorMessage();
        FlowLogger.Logger.LogWarning("An error message appeared when clicking the Login button: \"{ErrorMsg}\".", errorMsg);
        return null;
    }

    public string GetErrorMessage()
    {
        return WebDriverWrapper.GetText(_errorMsgLocator);
    }

    public bool IsErrorMessageVisible()
    {
        return WebDriverWrapper.DoesElementExist(_errorMsgLocator);
    }
}
