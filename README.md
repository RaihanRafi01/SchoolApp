The Student Information Management System is a web application developed using ASP.NET Core and .NET 6 MVC. The system allows users to manage student information efficiently. It includes functionalities to add new student records, edit existing records, view detailed information, and delete records. The application uses SQL Server for data storage and Entity Framework for database connectivity.

Key Features:

1. Database Design:
  Two tables in SQL Server: Student Table and Class Table.
  Student Table contains columns for ID (Primary Key), Name, Gender, Date of Birth, Class ID (Foreign Key), Created Date, and Modification Date.
  Class Table contains columns for ID (Primary Key), Name, Created Date, and Modification Date.
  Primary key and foreign key relationship established between Student Table and Class Table.

2. User Interface:
  Add New Student Info: Users can add new student information using a form with fields for Name, Class (dropdown), Date of Birth (calendar), and Gender (radio button).
  List of Students: Displays a table with columns for Name, Class, Date of Birth, Gender, and Action buttons (Edit, Details, Delete) for each student record.
  Edit: Users can edit student information through a form similar to the Add New Student Info form.
  Details: Provides a detailed view of a student's information.
  Delete: Allows users to delete student records.

3. Operations Workflow:
  Clicking on buttons (Add New Student Info, Edit, Details, Delete) opens a new page for the respective operation.
  Upon completion of the operation, users are automatically redirected to the updated list page displaying the latest information from the database.

4. Data Handling:
  Data for Created Date and Modification Date is assigned from the controller’s action result for create and edit operations.
  Class Table data is manually added to the database; no CRUD operations are required for the Class Table.

Technologies Used:

Backend: ASP.NET Core, .NET 6
Database: SQL Server
ORM: Entity Framework
Frontend: HTML, CSS
User Interface: Razor Pages, Bootstrap
Tools: Visual Studio, SQL Server Management Studio

Note: The Student Information Management System provides an intuitive and user-friendly interface for managing student records. It ensures data integrity through a well-designed database schema and offers seamless interactions for users. The application is built to streamline the process of managing student information in an educational environment.
