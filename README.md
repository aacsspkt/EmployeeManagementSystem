# EmployeeManagementSystem

Himalaya Organic Farm is an agro-industrial corporation with vast plantations and factories in the north of Nepal. With its huge labor force its human resources department formerly had a flat file system for handling employee information. This wasn’t quite good as it couldn’t meet up with the ever changing needs of the corporation. The aim of this project is to build a system whereby Himalaya Organic Farm can safely keep and manage employee information. It is to act a source of knowledge for strategic decision making by Himalaya Organic Farm management and other external agencies connected to the corporation. The following are the requirements of the software for managing the Employee Management System.

This system is used by two users Admin and Employee.
Functionality performed by Admin Users:
* Login for Admin
* Logout functionality
* Dashboard for Admin User

### Manage Department
*	Adding  New Department
*	Edit the existing  Department
*	Deleting Department
*	View Details of Department
*	Listing of All Department

### Manage Designation
*	Adding  New Designation
*	Edit the existing  Designation
*	Deleting Designation
*	View Details of Designation
*	Listing of All Designation

### Employee
*	Adding  New Employee
*	Edit the existing  Employee
*	Deleting Employee
*	View Details of Employee
*	Listing of All Employee

### Leave
*	Adding  New Leave
*	Edit the existing  Leave
*	Deleting Leave
*	View Details of Leave
*	Listing of All Leave

### Salary
*	Adding  New Salary
*	Edit the existing  Salary
*	Deleting Salary
*	View Details of Salary
*	Listing of All Salary

### Vacancy
*	Adding  New Vacancy
*	Edit the existing  Vacancy
*	Deleting Vacancy
*	View Details of Vacancy
*	Listing of All Vacancy

### Reports of the project Online Employee Management System
* Report of All Department
* Report of All Designation
* Report of All Employees 
* Report of All Leave
* Report of All Salary
* Report of All Vacancy

Note: Report can be viewed by filtering multiple parameters.


## How to use it?

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

