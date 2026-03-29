@Variant:Chrome
@Variant:Edge
Feature: Attempting login with no username shows error

    Background:
        Given the user is on the login page

    Scenario Outline: Clearing all credentials shows username required error
        Given the user enters username "<username>" and password "<password>"
        When the user clears the username
        And the user clears the password
        And the user clicks the login button
        Then the user should see the error "Username is required"
        Examples:
            | username                | password     |
            | standard_user           | secret_sauce |
            | locked_out_user         | secret_sauce |
            | problem_user            | secret_sauce |
            | performance_glitch_user | secret_sauce |
            | error_user              | secret_sauce |
            | visual_user             | secret_sauce |
            | invalid_user            | secret_sauce |
            | standard_user           | sauce_secret |
