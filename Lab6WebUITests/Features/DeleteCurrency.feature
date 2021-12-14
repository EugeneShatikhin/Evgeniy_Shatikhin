Feature: DeleteCurrency

	Background: 
		Given I am logged in
		And Currency exists

	@ScDeleteCurrency
	Scenario Outline: Deleting currency
	Given some <currency> is selected
	When I click Delete
	Then it should be deleted

	Examples: 
		| currency |
		| UAH      |