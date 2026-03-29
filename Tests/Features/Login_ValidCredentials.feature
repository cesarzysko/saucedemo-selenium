@Variant:Chrome
@Variant:Edge
Feature: Attempting login with valid credentials loads main page

    Background:
        Given the user is on the login page

    Scenario Outline: Logging in with valid credentials loads the main page
        Given the user enters username "<username>" and password "<password>"
        When the user clicks the login button
        Then the main page should load
        Examples:
          | username                | password     |
          | standard_user           | secret_sauce |
          | problem_user            | secret_sauce |
          | performance_glitch_user | secret_sauce |
          | error_user              | secret_sauce |
          | visual_user             | secret_sauce |
