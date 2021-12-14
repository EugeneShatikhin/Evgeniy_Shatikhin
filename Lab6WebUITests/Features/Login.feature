Feature: Log in
	Log in system
	Background:
		Given I am trying to log in

	@ScLogin
	Scenario Outline: Successfully logging in system
		Given I entered username <username>
		And entered password <password>
		When i pressed Login
		Then i should be logged in

	Examples:
		| username | password |
		| Admin    | admin123 |

	@ScLogin
	Scenario Outline: Error logging in
		Given I entered username <username>
		And entered password <password>
		When i pressed Login
		Then i should see <error message>
		
	Examples: 
		| username | password | error message       |
		| Admin    | idkpass  | Invalid credentials |
		| nobody   | nothing  | Invalid credentials |