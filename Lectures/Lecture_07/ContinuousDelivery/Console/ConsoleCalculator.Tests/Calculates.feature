Feature: Calculates
	In order to Calculate product price
	As a Personal Banker
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 5 into the calculator
	And I have entered 2 into the calculator
	When I press any key
	Then the result should be 7 on the screen
