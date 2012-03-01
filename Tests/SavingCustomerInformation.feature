Feature: Saving Customer Information
As a sales manager
I want to save a customer’s details
So that I can contact them later

Scenario: HappyPath
Given I am in the New Customer window
When I enter a company name in the company name field
When I enter a contact e-mail address in the e-mail field
When I click on the Save button
Then I should see a newly added customer in the list of customers filed by their company name

Scenario: Blank Company Name
Given I am in the New Customer window
When I leave the company name field blank
When I click on the Save button
Then I should be presented with an error saying so