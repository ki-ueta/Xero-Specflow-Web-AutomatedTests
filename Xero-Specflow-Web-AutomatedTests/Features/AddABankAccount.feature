﻿Feature: Add a Bank Account
As a Xero User,
In order to manage my business successfully,
I want to be able to add an "ANZ(NZ)" bank account inside any Xero Organisation

Scenario: add a ANZ-NZ bank account
	Given I successfully log in
	When I add an ANZ(NZ) bank account
	Then a new bank account is recorded in the system