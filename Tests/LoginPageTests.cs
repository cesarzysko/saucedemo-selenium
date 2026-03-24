namespace Tests;

using Business;
using Core;
using Core.WebDriver.Factory;
using TestData;

[TestFixtureSource(typeof(Config), nameof(Config.DriverFactories))]
[Parallelizable(ParallelScope.All)]
public sealed class LoginPageTests(IWebDriverFactory driverFactory)
    : TestsBase(driverFactory)
{
    [TestCaseSource(typeof(LoginPageTestsData), nameof(LoginPageTestsData.GetAnyCredentials))]
    public void Login_FeedCredentialsAndClearAll_ShowsUsernameRequiredMessage(string username, string password)
    {
        const string expectedErrorMsg = "Username is required";

        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterUsername(username)
            .EnterPassword(password)
            .ClearUsername()
            .ClearPassword()
            .ClickLoginButton();
        string errorMsg = loginPage.GetErrorMessage();

        // Assert
        errorMsg.Should().Contain(expectedErrorMsg);
    }

    [TestCaseSource(typeof(LoginPageTestsData), nameof(LoginPageTestsData.GetAnyCredentials))]
    public void Login_FeedCredentialsAndClearPassword_ShowsPasswordRequiredMessage(string username, string password)
    {
        const string expectedErrorMsg = "Password is required";

        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterUsername(username)
            .EnterPassword(password)
            .ClearPassword()
            .ClickLoginButton();
        string errorMsg = loginPage.GetErrorMessage();

        // Assert
        errorMsg.Should().Contain(expectedErrorMsg);
    }

    [TestCaseSource(typeof(LoginPageTestsData), nameof(LoginPageTestsData.GetValidCredentials))]
    public void Login_FeedValidCredentials_LoadsMainPage(string username, string password)
    {
        const string expectedLockedOutMsg = "Sorry, this user has been locked out";

        // Arrange
        var loginPage = new LoginPage();

        // Act
        MainPage? mainPage = loginPage
            .EnterUsername(username)
            .EnterPassword(password)
            .ClickLoginButton();
        var isErrorMsgVisible = loginPage.IsErrorMessageVisible();

        // Assert
        if (isErrorMsgVisible)
        {
            var errorMsg = loginPage.GetErrorMessage();
            errorMsg.Should().Contain(expectedLockedOutMsg);
            return;
        }

        mainPage.Should().NotBeNull("because login should have succeeded without errors");
        mainPage.IsLoadedCorrectly().Should().BeTrue("because all main page elements should be located");
    }
}
