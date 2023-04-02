# Task assignment
**Stack**: Blazor + API controllers, MSSQL
**Objective**: Phonebook contacts
**Use**: Dependency Injection
**MSSQL single table**: Contact, field: FirstName, LastName, bool IsActive, datetime BirthDate, Email, TelephoneNumber

## Gui screen 1 - overview of all contacts with search
- overview of all contacts, search via FirstName, LastName
- search via birthdate from-to
- search via IsActive
- search via phone number, whether it is entered in the filter with or without spaces, i.e. in any way
- possibility to add a new contact
- possibility to go to the edit screen

## Gui screen 2 - edit contact
- string fields
- date field
- checkbox for IsActive
- masked edit for phone number = display in segments of three digits (NNN NNN NNN)
- validation of the email that it is in the correct format
- display the current age of the contact, automatically on the fly recalculated when I change the BirthDate field

