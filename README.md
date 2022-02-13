# EmployeeManagementSystem

This system is used by two users Admin and Employee.
Functionality performed by Admin Users:
* Login for Admin
* Logout functionality
* Dashboard for Admin User
* Manage Department
* Manage Designation
*	Manage Employee
* Manage Leave
* Salary
* Vacancy

## Installation

### Tools required
First of all you'll require some tools as mentioned below:
* Visual Studio 2019
* MS-SQL Server
* SQL Server Management Studio (SSMS)
* Git

### Steps to use it:
* After installing all the required tools or if you have them already installed, either download the source code or clone it using git.
* Open the SSMS and create a new database for the project.
* Then open the Visual Studio and go to server explorer and create a data connection to the database you created.
* Right click on the connection, click on properties and copy the connection string.
* Then go to the solution explorer and open "appsettings.json" file.
* Remove the string value for DefaultConnection and paste the connection string you copied earlier as a string.
* Open the package manager console from the tools tab situated at the top of visual studio.
* Run command "update-database".
* Then once more open the SSMS and populate the table with some data especially the Users table with at least one row with 0 as value in the Role column. You can take examples from the data from excel file if required. 
* Then build and run the project from the visual studio.
* Use the same user credential as inserted in the user table.

