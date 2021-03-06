 Authentication.featureCucumber

Feature: Authentication
	In order to SOMETHING
	As SOMEONE
	I want to SOMETHING
 
Scenario: Registering with a valid e-mail
	Given I am on the registration page
	When I fill the "E-Mail" field with "valid@email.com"
	And I click "OK"
	Then I should be on the confirmation page
 
Scenario: Registering with an invalid e-mail
	Given I am on the registration page
	When I fill the "E-Mail" field with "invalidemail.com"
	And I click "OK"
	Then I should see the error "Invalid e-mail, please verify and try again."
	And I should be on the registration page
	
Scenario: Registering with an empty e-mail
	Given I am on the registration page and had given a file to print
	When I fill the "E-mail" field with ""
	And I click "OK"
	Then I should see the error "Invalid e-mail, please verify and try again."
	And I should be on the registration page
	And I dismiss the browser //fechar browser
