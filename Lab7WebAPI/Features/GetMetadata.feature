Feature: GetMetadata
	Get file metadata

Scenario Outline: Get existing file metadata
	Given <file> is uploaded to Dropbox
	When I send POST request to Dropbox <endpoint>
	Then I should get response "200 OK"
	Examples: 
		| file                | endpoint                                               |
		| /Lab7WebAPI/dog.png | https://api.dropboxapi.com/2/sharing/get_file_metadata |