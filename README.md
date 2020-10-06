# Xero-Specflow-Web-AutomatedTests
## How to run automated test
1. Download sourcecode
2. Open a solution using Visual Studio
3. Install nuget packages and required sdk.
4. Compile and build solution
5. Specify configuration in appsettings.json
    - Username: Xero account user name
    - Password: Xero account password
    - Browser: "CHROME" or "FIREFOX"
    - FirefoxBinaryPath: by default, it is "C:\Program Files\Mozilla Firefox\firefox.exe"
6. In Unit Test Explorer, right click on "AddANZ_NZBankAccount" test and click "Run Unit Test"
7. Get test result including screenshots.

## Exclusion due to time constrain.
 - Assertions
    - If a default business is not exist, one should be created
    - After adding a new account, Bank logo should be displayed on bank account details
 - Test Frameworks
   - Logging 
   - For multiple scenarios/features, reusing opened browsers.
   - Dispose all orphaned browsers
 - Source code
   - No comments in commited changes since no other contributors and there will be no more changes in the future.
