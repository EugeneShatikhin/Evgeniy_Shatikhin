Feature: AddCurrency
	Add currency for existing Pay Grade
	Background:
		Given I am logged in
		And EvgShat Pay Grade is already created

	@ScAddCurrency
	Scenario Outline: Successfully add currency
		Given currency <currency> is entered
		And minimum salary <minimum> is entered
		And maximum salary <maximum> is entered
		When I click Save
		Then new currency should be added

		Examples: 
			| currency              | minimum | maximum |
			| UAH - Ukraine Hryvnia | 40000   | 50000   |

	@ScAddCurrency
	Scenario Outline: Adding currency fails
		Given currency <currency> is entered
		And minimum salary <minimum> is entered
		And maximum salary <maximum> is entered
		When I click Save
		Then new currency is not added
		And I receive <error message>

		Examples: 
			| currency                   | minimum | maximum | error message                        |
			| UAH - Ukraine Hryvnia      | 40000   | 50000   | Already exists                       |
			| USD - United States Dollar | 5000    | 4500    | Should be higher than Minimum Salary |
			| USD - United States Dollar | 3000a   | 4500    | Should be a positive number          |