### Site for testing: [saucedemo.com](https://www.saucedemo.com)

#### UC-1 Test Login form with empty credentials:
- Enter any credentials into "Username" and "Password" fields.
- Clear the inputs.
- Click the "Login" button.
- Check that an error message "Username is required" appears.
<br/><br/>
#### UC-2 Test Login form with only Username provided:
- Enter any username.
- Enter password.
- Clear the "Password" field.
- Click the "Login" button.
- Check that an error message "Password is required" appears.
<br/><br/>
#### UC-3 Test Login form with valid credentials:
- Enter username using any value from the section “Accepted usernames are”.
- Enter a password from the section “Password for all users”.
- Click “Login” button and validate that main page contains the following elements:
  - Burger menu button,
  - Label “Swag Labs”,
  - Shopping cart icon,
  - Dropdown with sorting filters,
  - List of inventory items.
<br/><br/>

Provide possibility to execute tests in parallel, add logging to track execution flow and use data-driven testing approach.

Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.

**To perform the task use the various of additional options:**<br/>
Test Automation tool: Selenium WebDriver;<br/>
Browsers: 1) Chrome; 2) Edge;<br/>
Locators: CSS;<br/>
Test Runner: NUnit;<br/>
Assertions: Fluent Assertion;<br/>
_[Optional] Patterns: 1) Singleton; 2) Factory method; 3) Abstract Factory;_<br/>
_[Optional] Test automation approach: BDD;_<br/>
_[Optional] Loggers: NUnit._<br/>