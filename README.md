# Download
1. Use [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo?view=vs-2022) to clone repository OR download .zip archive of branch
2. Download [Specflow](https://docs.specflow.org/projects/getting-started/en/latest/index.html)
3. Navigate to BasePageObject.cs, find 'Global' class, change 'path' to the path of your local driver for a browser of choice. A copy of ChromeDriver is provided along code, you may download other drivers [here](https://www.selenium.dev/documentation/webdriver/getting_started/install_drivers/). 

# Run tests
1. Use Visual Studio test runner to better understand the process.
2. Alternatively, run cmd.exe in folder. Type in 'dotnet test' to run all tests, type in 'dotnet test -t' to list all tests, type in 'dotnet test --filter {NAME}' to run tests cointaining {NAME}. More information [here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)

# Info
Cucumber feature files and step definitions can be found at Lab6WebUITests\Features\  
Due to the nature of these tests, they are better run in this order:
1. LogInFeature
2. PayGradeAddFeature (1 - Unique, 2 - Which already exists)
3. AddCurrencyFeature (1 - Successfully add currency, 2 - Adding currency fails)
4. DeleteCurrencyFeature
5. DeletePayGradeFeaturu

