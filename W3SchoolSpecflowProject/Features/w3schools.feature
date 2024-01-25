Feature: User Registration and Login

@myFirstTest
Scenario: Successful User Registration
Given a user is on the registration page.
When the user enters valid registration details with Username as "vinaykumar56@gmail.com" and Password as "vG@561200"
And Enter details with FistName as "vi" and LastName as "dfdf"
Then a new user account should be created successfully.

Scenario: Existing User Validation
Given a user is on the registration page.
When the user tries to register with the existing userid with Username as "vinaykumar56@gmail.com" and Password as "vG@561200"
And Enter details with FistName as "vinay" and LastName as "kumar"
Then an error message should be displayed, and the registration should not proceed with ErrorMessage as "already have a user"

Scenario: Missing Required Fields
Given a user is on the registration page.
When the user submits the registration form with missing required fields
Then appropriate error messages should be displayed, and the registration should not proceed with ErrorMessage as "Please enter an email"

Scenario: Invalid Login Attempt
Given a user navigates to the login page.
When the user enters invalid or valid credentials with Email as "vinaykuar56@gmail.com" and Password "viN@12568e"
Then an error message should be displayed, and the user should not be logged in with ErrorMessage as "user with this email does not exist"
