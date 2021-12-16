Feature: Delete
	Delete file

Scenario Outline: Delete existing file
	Given <file> is uploaded to Dropbox
	When I send POST request to Dropbox <endpoint>
	Then I should get response "200 OK"
	Examples: 
		| file                | endpoint                                     |
		| /Lab7WebAPI/dog.png | https://api.dropboxapi.com/2/files/delete_v2 |