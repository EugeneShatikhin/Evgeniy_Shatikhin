Feature: DeletePayGrade
	Background: 
		Given Pay Grade exists

	@ScDeletePayGrade
	Scenario Outline: Deleting pay grade
	Given pay grade <pay grade> is selected
	When I click Remove
	Then pay grade should be deleted

	Examples: 
		| pay grade |
		| EvgShat   |