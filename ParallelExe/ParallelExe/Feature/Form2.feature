Feature: Form2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: User Detail form entry verification
	Given I navigate to application
	And I enter username and password
	| UserName | Password |
	| admin    | admin    |
	And I click login
	And I start entering user form details like
	| Initial | FirstName | MiddleName |
	| A       | Ashwini   | R          |
	And I click submit button 