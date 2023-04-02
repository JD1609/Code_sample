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


## Quick start
The application uses the entity framework to work with the database and uses migration. Therefore, before using the application, it is necessary to set up database migrations.

1. ) Change the connection string in **`appsettings.json`**
2. ) In the server application directory, run the **`dotnet ef database update`** CLI command to apply the database migration
> For instalation Entity Framework use CLI command `dotnet tool install --global dotnet-ef`
3. ) After applying migrations, you can run the application in VS


![image](https://user-images.githubusercontent.com/74508566/229358617-8539f979-0ea1-4644-bf73-ee68bd755595.png)


![image](https://user-images.githubusercontent.com/74508566/229358688-4a984318-3435-4200-a555-408324f79fd9.png)
