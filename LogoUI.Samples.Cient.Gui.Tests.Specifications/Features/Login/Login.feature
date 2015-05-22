Feature: Login
	In order to login into the system
	As an authenticated user
	I want to be able to login into the system

@Integration
Scenario: Automatically navigate to the login screen		
	When I open the application	
	Then Application automatically navigates to the login screen

@Integration
Scenario: Autopopulate Username for authenticated users
	Given I am an authenticated user with username 'Vasya'
	When I open the application
	Then Local authentication is automatically selected in the authentication options list
	And Username text box contains 'Vasya'

@Integration
Scenario: Display failed authentication message for unauthenticated users
	Given I am an unauthenticated user
	When I open the application
	Then Error message is displayed with the following text 'Unauthenticated user'

@Integration
Scenario: Clear username when user switched to the network authentication option
	Given I am an authenticated user with username 'Vasya'
	When I open the application
	And I select the network authentication option
	Then Username text box contains ''

