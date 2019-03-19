Feature: Calculates
	In order to Calculate product price
	As a Personal Banker
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 5 into the first field
	And I have entered 2 into the second field
	When I press Calculate
	Then the result should be 7 on the screen
