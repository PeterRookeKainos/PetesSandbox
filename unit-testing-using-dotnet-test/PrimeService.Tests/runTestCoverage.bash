!#/bin/bash

# This script runs the tests and generates a coverage report.
dotnet test --no-build --verbosity normal --collect:"XPlat Code Coverage" --results-directory ./TestResults
# Check if the test results directory exists
if [ -d "./TestResults" ]; then
    echo "Test results directory exists."
else
    echo "Test results directory does not exist. Exiting."
    exit 1
fi
# Check if the coverage report exists
if [ -f "./TestResults/coverage.cobertura.xml" ]; then
    echo "Coverage report exists."
else
    echo "Coverage report does not exist. Exiting."
    exit 1
fi
# Generate the HTML report from the coverage report
reportgenerator -reports:./TestResults/coverage.cobertura.xml -targetdir:./TestResults/coverage-report -reporttypes:Html
# Check if the HTML report was generated
if [ -d "./TestResults/coverage-report" ]; then
    echo "HTML coverage report generated successfully."
else
    echo "Failed to generate HTML coverage report. Exiting."
    exit 1
fi
# Open the HTML report in the default browser
if command -v xdg-open > /dev/null; then
    xdg-open ./TestResults/coverage-report/index.html
elif command -v open > /dev/null; then
    open ./TestResults/coverage-report/index.html
else
    echo "No suitable command found to open the HTML report. Please open it manually."
fi

# Print the location of the coverage report
echo "Coverage report is located at: ./TestResults/coverage-report/index.html"
# Print the location of the test results
echo "Test results are located at: ./TestResults"
# Print the location of the coverage report in Cobertura format
echo "Cobertura coverage report is located at: ./TestResults/coverage.cobertura.xml"
# Print the location of the test results in TRX format
echo "Test results in TRX format are located at: ./TestResults/TestResults.trx"
# Print the location of the test results in HTML format
echo "Test results in HTML format are located at: ./TestResults/TestResults.html"
# Print the location of the test results in XML format
echo "Test results in XML format are located at: ./TestResults/TestResults.xml"
# Print the location of the test results in JSON format
echo "Test results in JSON format are located at: ./TestResults/TestResults.json"
# Print the location of the test results in JUnit format
echo "Test results in JUnit format are located at: ./TestResults/TestResults.junit.xml"
# Print the location of the test results in NUnit format
echo "Test results in NUnit format are located at: ./TestResults/TestResults.nunit.xml"
# Print the location of the test results in xUnit format
echo "Test results in xUnit format are located at: ./TestResults/TestResults.xunit.xml"
# Print the location of the test results in TeamCity format
echo "Test results in TeamCity format are located at: ./TestResults/TestResults.teamcity.txt"
# Print the location of the test results in Markdown format
echo "Test results in Markdown format are located at: ./TestResults/TestResults.md"
# Print the location of the test results in CSV format
echo "Test results in CSV format are located at: ./TestResults/TestResults.csv"
