namespace Tests.Features;

using Business;
using TechTalk.SpecFlow;

[Binding]
public sealed class LoginStepDefinitions
{
    private LoginPage? _loginPage;
    private MainPage? _mainPage;

    private LoginPage LoginPage => _loginPage!;

    [Given("the user is on the login page")]
    public void GivenTheUserIsOnTheLoginPage()
    {
        _loginPage = new LoginPage();
    }

    [Given("the user enters username \"(.*)\" and password \"(.*)\"")]
    public void GivenTheUserEntersUsernameAndPassword(string username, string password)
    {
        LoginPage.EnterUsername(username).EnterPassword(password);
    }

    [When("the user clears the username")]
    public void WhenTheUserClearsTheUsername()
    {
        LoginPage.ClearUsername();
    }

    [When("the user clears the password")]
    public void WhenTheUserClearsThePassword()
    {
        LoginPage.ClearPassword();
    }

    [When("the user clicks the login button")]
    public void WhenTheUserClicksTheLoginButton()
    {
        _mainPage = LoginPage.ClickLoginButton();
    }

    [Then("the user should see the error \"(.*)\"")]
    public void ThenTheUserShouldSeeTheError(string expectedMessage)
    {
        LoginPage.GetErrorMessage().Should().Contain(expectedMessage);
    }

    [Then("the main page should load")]
    public void ThenTheMainPageShouldLoad()
    {
        _mainPage.Should().NotBeNull("because login should have succeeded without errors");
        _mainPage!.IsLoadedCorrectly().Should().BeTrue("because all main page elements should be located");
    }
}
