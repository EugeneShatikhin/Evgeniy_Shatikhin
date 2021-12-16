Feature: UploadFile
	Uploads file to Dropbox

Scenario Outline: Upload some picture
	Given I have some <picture> i want to upload to <directory>
	When I send POST request to Dropbox <endpoint>
	Then I should get response "200 OK"
	Examples:
		| picture      | directory           | endpoint                                      |
		| pics/dog.jpg | /Lab7WebAPI/dog.png | https://content.dropboxapi.com/2/files/upload |