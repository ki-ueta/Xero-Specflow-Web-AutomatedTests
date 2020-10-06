# Xero-Specflow-Web-AutomatedTests
## How to run automated test
1. Download sourcecode.
2. Install nuget packages and required sdk.
3. Compile and build solution
4. Specify configuration in appsettings.json
    - Username: Xero account user name
    - Password: Xero account password
    - Browser: "CHROME" or "FIREFOX"
    - FirefoxBinaryPath: by default, it is "C:\Program Files\Mozilla Firefox\firefox.exe"
5. In Unit Test Explorer, right click on "AddANZ_NZBankAccount" test and click "Run Unit Test"
6. Get test result including screenshots.

## Exclusion due to time constrain.
 - Assertions
    - If a default business is not exist, one should be created
    - After adding a new account, Bank logo should be displayed on bank account details
 - Test Frameworks
   - Logging 
   - For multiple scenarios/features, reusing opened browsers.
   - Dispose all orphaned browsers
