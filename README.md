# Download
1. Use [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo?view=vs-2022) to clone repository OR download .zip archive of branch
2. Download [Specflow](https://docs.specflow.org/projects/getting-started/en/latest/index.html)
3. Navigate to Request.cs, find 'Authorization' class, change 'Token' to your Dropbox app Bearer token.

# Run tests
1. Use Visual Studio test runner to better understand the process.
2. Alternatively, run cmd.exe in folder. Type in 'dotnet test' to run all tests, type in 'dotnet test -t' to list all tests, type in 'dotnet test --filter {NAME}' to run tests cointaining {NAME}. More information [here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)

# Info
Cucumber feature files and step definitions can be found at Lab7WebAPI\Features\  
Code utilizes Builder pattern in Request.cs and step definitions.
