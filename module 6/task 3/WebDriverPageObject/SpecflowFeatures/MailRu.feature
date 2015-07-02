Feature: MailRU
In order to send emails from my emailbox
As a user
I want to be able to login and to send emails

@login
Scenario: Login to emailbox
	Given mail.ru is opened
	When I enter email address, password and click login button
	Then The emailbox title is displayed


@creation
Scenario: Email creation and saving
	Given Empty Email is opened
	When I fill in  <address> and <subject> and <message>
		And I click Save button
	Then The Email exists in Drafts category 


