BDD
===

Authentication.featureCucumber 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 Feature: Authentication 	In order to SOMETHING 	As SOMEONE 	I want to SOMETHING   Scenario: Registering with a valid e-mail 	Given I am on the registration page 	When I fill the "E-Mail" field with "valid@email.com" 	And I click "OK" 	Then I should be on the confirmation page   Scenario: Registering with an invalid e-mail 	Given I am on the registration page 	When I fill the "E-Mail" field with "invalidemail.com" 	And I click "OK" 	
