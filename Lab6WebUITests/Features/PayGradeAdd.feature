Feature: PayGradeAdd
	Add new PayGrade
	Background:
		Given I am logged in
		And I want to add new Pay Grade

	@ScPayGrade
	Scenario Outline: I want to create uniquely named Pay Grade
		Given I am entering name <name>
		When i press Save
		Then new Pay Grade should be created

	Examples: 
		| name    |
		| EvgShat |

	@ScPayGrade
	Scenario Outline: I want to create Pay Grade which already exists
		Given I am entering name <name>
		When i press Save
		Then nothing should happen

	Examples: 
		| name    |
		| EvgShat |