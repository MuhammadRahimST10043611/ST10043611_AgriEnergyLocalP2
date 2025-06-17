Muhammad Rahim
ST10043611
Prog7311 
POE PART 2
Readme

![image](https://github.com/user-attachments/assets/5b614ab7-f4f1-4a76-b0cc-061ed03dba21)


Agri-Energy Connect - Farmer Product Management System

Overview
Agri-Energy Connect is a web-based platform designed to facilitate product management for farmers and agricultural employees. The system enables farmers to manage their products and discover what other farmers are offering, while employees can administer farmer accounts and access comprehensive product data across the platform.
Please Note!
•	SQL Lite is being used and Razor View as prescribed by lecture
•	If you struggling to see any image please zoom in to see the images clearer.
System Requirements
1.	.NET 7.0 SDK or later
2.	Visual Studio 2022
3.	SQLite (included in the project

Setup Instructions
Option 1: Using Visual Studio 2022

1.	Install Prerequisites:
•	Install thee Visual Studio 2022 (Community edition which is the free version)
•	During installation, ensure the "ASP.NET and web development" workload is selected

2.	Clone or Download the Project:
•	Download the zip file from GitHub Repository by using this link: https://github.com/MuhammadRahimST10043611/AgriEnergyLocalP2/tree/Final-Code

![image](https://github.com/user-attachments/assets/1dcb36c7-2f48-4fe5-905b-32e35a38118a)

•	Extract the zip file onto your pc either using WinRAR, Windows zip or 7zip

![image](https://github.com/user-attachments/assets/a3b52d62-9164-4f3a-9895-13fef15ee51f)


3.	Open the Project:
•	Find where you extracted the project will usually be in your downloaded folder
•	Open the project till the point where you see this, “ProgAgriP2New.sln” file double click on it, and it will automatically open the project in Visual Studio 2022

![image](https://github.com/user-attachments/assets/a1e27ac7-67b4-43b0-adc6-9e68914c49e2)


4.	Restore Dependencies:
•	As soon as you double click that file it will open up the project which then it will automatically begin to Restore NuGet Packages in the case that it does not follow the two steps below this.
•	Right-click on the solution in Solution Explorer
•	Select "Restore NuGet Packages"

![image](https://github.com/user-attachments/assets/edd17524-66d1-4602-8608-9e8f17e5abeb)


•	Below is the full list of the NuGet Packages that are required for this application to work. Very Important to make sure that it is using these versions.

![image](https://github.com/user-attachments/assets/d2efd3ad-9bad-43ac-be9f-4f14d55b88f2)



5.	Build the Solution:
•	From the top menu in VS Studio you will need to select Build → Build Solution

![image](https://github.com/user-attachments/assets/ad0179f8-4189-4cf9-b589-c82583ad5795)


6.	Run the Application:
•	Press the “Green Play Button” found at the top of the screen in the middle to successfully start the application

![image](https://github.com/user-attachments/assets/316dbabf-987a-456f-8b07-818d2b33984a)


Database Information

Please Note, that this application uses SQLite for database storage. The database file is already created so there is no need to run anything from your side. The database already comes with prepopulated data in it. In the case that the database is not present simply run the application and the database will be created with prepopulated data. The database file is located at:
ProgAgriP2New/Data/LocalProgAgriDb.db
PLEASE NOTE
If you would like to view the contents in the database, you will need to have SQLite Extension Installed in your VS Studio 2022 Please follow the steps down below to be able to view the contents, structure, and data of the Database:
1.	Please open up extensions and click on, “Manage Extensions”
 
![image](https://github.com/user-attachments/assets/4f0f6a95-8a9f-4463-9bb0-f8a29b844be6)


2.	Afterwards click on , “Browse” then type in, “SQLite” and chose the one that I chose in the image down below then click on, “Install”. You might be asked to close VS Studio in order for the Extension to install successfully then follow the prompts that appear afterwards once done you can reopen the project and carry on from step 3 

![image](https://github.com/user-attachments/assets/0ad7cab4-2a8e-49b9-8729-0205196b8083)


3.	Next after it is installed its time to view the contents in our Database first click on, “View”, then, “Other Windows” and lastly on, “SQLite/SQL Server Compact Toolbox”

![image](https://github.com/user-attachments/assets/df0cab3a-1613-4684-bad8-b7847df59205)


4.	It will then bring up this on the left hand side of your screen, Make Sure you click on the middle icon called, “Add SQLite Connection”

![image](https://github.com/user-attachments/assets/1a39bfa1-f1b8-4126-8382-95fd8b5e7b46)


5.	It will then bring up this popup proceed to click on, “Browse”

![image](https://github.com/user-attachments/assets/674cf9ee-95a8-4546-8268-baae21e85e2e)


6.	This when then bring up this file explorer popup please navigate to where the Database is found it should be located ProgAgriP2New/Data/LocalProgAgriDb.db make sure it looks like the picture before clicking on Open

![image](https://github.com/user-attachments/assets/f178fbe2-510e-4fc2-89a5-00bf24d8869e)


7.	Next click on, “Test Connection”

![image](https://github.com/user-attachments/assets/6eac8df5-fca8-45b0-b6ed-55519c0cf492)

 
8.	This will popup click on, “OK” then click on the, “Close” button found at the bottom

![image](https://github.com/user-attachments/assets/cb44fdc5-d7b5-4e77-8457-52267309d1e4)


9.	If you followed all the steps the database will appear here if you want to view the data in the table. You will first need to click on, “Table” dropdown menu it will now show all the tables found in the database to view the data that is getting sent to these tables you will need to right click on the desired table and click on, “Edit Top 200 Rows” this will then proceed to show the data in the tables.

![image](https://github.com/user-attachments/assets/73f89654-f5a8-4e85-9955-82a8f5aed5e1)


10.	Product Tables DATA

![image](https://github.com/user-attachments/assets/71346b78-7d3d-443f-a2d4-66c3dcb6f29d)


11.	Employee Tables DATA

![image](https://github.com/user-attachments/assets/e875a096-9e17-4653-aef7-713b94be16b9)


12.	Farmer Tables DATA

![image](https://github.com/user-attachments/assets/d3b14fe3-18e5-4464-806e-816cd1979c87)


13.	Table Contents for all tables

![image](https://github.com/user-attachments/assets/593ee249-78b8-441a-ad05-a06cde9a1324)


System Functionality
User Roles
The system supports two user roles:
1. Farmer Role
Farmers can:
•	Log in to their personal account
![image](https://github.com/user-attachments/assets/520ae3c7-4500-4c16-9f21-24bdaea7559a)
![image](https://github.com/user-attachments/assets/73a69c50-0792-4b4d-9be0-29a60165e852)


•	View their own product listings
![image](https://github.com/user-attachments/assets/73472b25-dcb4-4d01-a3b9-90870a74f29c)



•	Add new products to their profile
![image](https://github.com/user-attachments/assets/bf723a8d-876e-4eb4-88e9-dcc15e12682b)






•	Edit existing product details
![image](https://github.com/user-attachments/assets/d061287e-03c8-409b-a517-750a64f2a6d2)

•	View other farmers' products and contact information
![image](https://github.com/user-attachments/assets/759e08dd-3525-4c63-aaea-d235bf175c27)


•	Filter and sort product listings
![image](https://github.com/user-attachments/assets/fe0eb295-7f58-4fff-85d5-cfeed8959851)
![image](https://github.com/user-attachments/assets/32c86983-9420-409c-a825-b3b8cff8140c)


 

2. Employee Role
Employees (administrators) can:

•	Log in to their account

![image](https://github.com/user-attachments/assets/5082baba-ed45-4340-bdd9-bd403f06077a)


![image](https://github.com/user-attachments/assets/df83fa86-8823-4c88-bde8-b757c764da02)


•	Add new farmer profiles

![image](https://github.com/user-attachments/assets/99073f6f-afda-4916-af38-9dc17a00d4bd)



•	Edit existing farmer profiles

![image](https://github.com/user-attachments/assets/621480e7-3713-41f1-ac05-4f489bb84eb0)

![image](https://github.com/user-attachments/assets/d0d22723-079f-4ccb-bdf0-5a639ef8d764)


•	Delete farmer profiles

![image](https://github.com/user-attachments/assets/96bdedea-56ea-4dff-926a-07d810b87533)


•	View all products from all farmers

![image](https://github.com/user-attachments/assets/822d4630-5357-4330-a624-e5b11f45c77f)

 
•	Filter products by farmer, category, and date range

![image](https://github.com/user-attachments/assets/e981b4e9-c243-48f4-8919-ceca9eab8b5b)

![image](https://github.com/user-attachments/assets/0d6a885b-5787-46ff-ba6c-e1d379e8a1c7)

![image](https://github.com/user-attachments/assets/f4413342-ec78-48eb-b976-68b6659d6457)


•	Add new employee accounts
 
![image](https://github.com/user-attachments/assets/61058775-e99e-4ddd-b50c-2987a31058d5)


•	Manage employee accounts

![image](https://github.com/user-attachments/assets/313f5591-9aef-4dcb-9049-cfe67c88e0fe)


•	Delete products

![image](https://github.com/user-attachments/assets/d01df9fa-3771-486a-a1bf-072ae7d06fd0)





Login Credentials
Please use any one of these pre-populated users with the following login credentials found below:

Farmers:
1.	Lionel Messi
•	Email: messi@farm.com
•	Password: Farmer123@#
2.	Cristiano Ronaldo
•	Email: ronaldo@farm.com
•	Password: Farmer123#
3.	Mohamed Salah
•	Email: salah@farm.com
•	Password: Farmer123@
4.	Kevin De Bruyne
•	Email: kdb@farm.com
•	Password: Farmer123!

Employees:
1.	Pep Guardiola
•	Email: pep@progagri.com
•	Password: Admin12!#				
2.	Jurgen Klopp
•	Email: klopp@progagri.com
•	Password: Admin123@
3.	Carlo Ancelotti
•	Email: carlo@progagri.com
•	Password: Admin123@






Key Features and Workflows
For Farmers:
1.	Logging In: 
•	Navigate to the home page of the App
•	You will see the Agri-Energy Connect landing page with a welcoming message
•	Click the "Get Started Now" button to proceed to the login page
•	On the login page, select "Farmer" from the "Login As" dropdown menu
•	Enter your email (e.g., messi@farm.com)
•	Enter your password, make sure the password includes the number and special character, or you will not be able to login (e.g., Farmer123!)
•	Click the "Show" button next to the password field to make sure that you entered in your password correctly
•	Click the "Login" button

2.	Product Management: 
•	After logging in to the App, you will be directed to the "My Products" page
•	The navigation bar at the top shows only three specific options that are meant for the farmers only: 
	"My Products" (current page)
	"Add Product"
	"View All Products"
To add a new product: 
•	Click "Add Product" in the navigation bar
•	Fill in the form: 
	Product Name: Enter your product name (e.g., "Organic Tomatoes")
	Category: Enter a category of your choice which you feel that the product belongs to (e.g., "Vegetables")
	Production Date: Select a date using the date picker option
•	Click the "Add Product" button to save
•	Click "Cancel" to return to My Products without saving
To edit existing products: 
•	From the "My Products" page, find the product you would like to edit
•	Click the blue "Edit" button next to the product
•	Modify the Product Name, Category, or Production Date
•	Click "Save Changes" to update the product
•	Click "Cancel" to discard changes

3.	Viewing Other Farmers' Products: 
•	Click "View All Products" in the navigation bar
•	You will see a "Filter Products" section at the top
•	Use the dropdown filters: 
	Category: Select from available categories or leave as "All Categories"
	Start Date: Choose a date to see products produced after this date
	End Date: Choose a date to see products produced before this date
	Items per page: Select 20, 50, or 100 items per page
	Sort Order: Choose "Newest First" or "Oldest First"
•	Click "Apply Filters" to update the product list
•	Click "Reset" to clear all filters
•	The table shows the following: 
	Farmer name
	Contact information (email and phone)
	Product details
•	Use the pagination controls I implemented at the bottom to navigate through pages

4.	Logout: 
•	Click "Logout" in the top-right corner of the navigation bar












For Employees:
1.	Logging In: 
•	Navigate to the home page
•	Click the "Get Started Now" button on the landing page
•	On the login page, select "Employee" from the "Login As" dropdown menu
•	Enter your email (e.g., pep@progagri.com)
•	Enter your password, make sure the password includes the number and special character, or you will not be able to login (e.g., Admin123!)
•	Use the "Show" button next to the password field to make sure that you entered in your password correctly
•	Click the "Login" button

2.	Navigating the Employee Dashboard: 
•	After logging in, you will see the "Product Management" page
•	The navigation bar shows five specific options that are only meant for the employee to see: 
1.	"Manage Products" (current page)
2.	"Manage Farmers"
3.	"Add Farmer"
4.	"Manage Employees"
5.	"Add Employee"

3.	Farmer Management: To add a new farmer: 
•	Click "Add Farmer" in the navigation bar
•	Fill in the form: 
1.	Farmer Name: Enter the farmer's full name
2.	Email: Enter a unique email address
3.	Password: Enter a password (must contain a number and special character)
4.	Address: Enter the farmer's address (optional)
5.	Phone Number: Enter a contact number (optional)
•	Click "Add Farmer" to save the information
•	Click "Cancel" to return without saving the information




To manage existing farmers: 
•	Click "Manage Farmers" in the navigation bar
•	You'll see a table with all farmers showing: 
1.	Name
2.	Email
3.	Address
4.	Phone Number
5.	Products Count
•	For each farmer, you can: 
1.	Click "Edit" (blue button) to modify farmer details
2.	Click "Delete" (red button) to remove the farmer (warning: this deletes all their products)
•	A confirmation prompt appears before deletion

4.	Product Management: On the "Manage Products" page: 
•	Use the "Filter Products" section to narrow down the product list: 
1.	Farmer: Select a specific farmer or "All Farmers"
2.	Category: Select a specific category or "All Categories"
3.	Start Date/End Date: Set date ranges
4.	Items per page: Choose 20, 50, or 100
5.	Sort Order: Choose "Newest First" or "Oldest First"
•	Click "Apply Filters" to update the view
•	Click "Reset" to clear all filters
•	The table shows: 
1.	Farmer name
2.	Product Name
3.	Category
4.	Production Date
5.	Actions (Delete button)
•	Click the red "Delete" button to remove a product
•	Use pagination controls at the bottom to navigate through pages






5.	Employee Management: To add a new employee: 
•	Click "Add Employee" in the navigation bar
•	Fill in the form: 
1.	Employee Name: Enter the employee's full name
2.	Email: Enter a unique email address
3.	Password: Enter a password (must contain a number and special character)
•	Click "Add Employee" to save the information
•	Click "Cancel" to return without saving the information

To manage existing employees: 
•	Click "Manage Employees" in the navigation bar
•	You'll see a table with all employees showing: 
1.	Name
2.	Email
3.	Actions (Edit/Delete)
•	For each employee: 
1.	Click "Edit" (blue button) to modify employee details
2.	Click "Delete" (red button) to remove the employee
•	A confirmation prompt appears before deletion

6.	Logout: 
•	Click "Logout" in the top-right corner of the navigation bar

General Navigation Tips:
•	The application logo in the top-left will always return you to the appropriate dashboard based on your role that you signed in as
•	Your email address is displayed in the top-right corner when logged in
•	All forms have included numerous validation messages that appear if information is missing or incorrect
•	Password fields have a "Show/Hide" toggle button for visibility to prevent miss entered passwords
•	The website has media queries so will work on most if not all phones, as the navigation bar is responsive and collapses on smaller screens (look for the hamburger menu icon)
•	Tables are scrollable on mobile devices
•	All buttons have been provided with visual feedback when hovered or clicked
•	After successful operations (add/edit/delete), you will automatically be redirected to the appropriate listing pages
Project Structure
This project follows the Model-View-Controller (MVC) pattern:
•	Models: Define the data structures and relationships of the project
•	Views: Contains the user interface templates
•	Controllers: Handle user requests and defines application logic
•	Services: Implements a business logic layer
•	Repositories: Handle all the data access operations
Troubleshooting
Common Issues:
1.	Database Connection Errors
•	Ensure the connection string in appsettings.json is correct
•	Check if the database file exists and is not corrupted
•	Verify the application has write permissions to the database location
2.	Build Errors
•	Run dotnet restore to ensure all dependencies are properly restored
•	Check for syntax errors or missing references in the code
3.	Runtime Errors
•	Check the application logs for detailed error information
•	Ensure all required services are running
•	Verify user permissions and authentication
If you encounter any issues not covered here, please contact the project administrator (Muhammad Rahim – st10043611@vcconnect.edu.za).

Security Considerations

•	User passwords are validated for minimum strength requirements such as the password must have at least one number and one special character.
•	Session-based authentication will protect against any unauthorised accesses
•	Role-based access control ensures that the users only have access to their appropriate features
•	User input is validated to help prevent any common security vulnerabilities

Future Enhancements

Potential future enhancements for the system include:
•	Implementing password hashing for improved security
•	Adding email verification for new user registrations
•	Implementing advanced search functionality
•	Adding reporting and analytics features
•	By developing a mobile application for enhanced accessibility
© 2025 Agri-Energy Connect. All rights reserved.


Reference list

Anon. 2017. Microsoft.AspNetCore.Session 2.3.0. [online] Nuget.org. Available at: <https://www.nuget.org/packages/Microsoft.AspNetCore.Session/> [Accessed 2 May 2025].
Anon. 2025a. : The Form element - HTML: HyperText Markup Language | MDN. [online] MDN Web Docs. Available at: <https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/form> [Accessed 2 May 2025].
Anon. 2025. ARIA - Accessibility | MDN. [online] developer.mozilla.org. Available at: <https://developer.mozilla.org/en-US/docs/Web/Accessibility/ARIA> [Accessed 2 May 2025].
Anon. 2025. Bootstrap 5 Forms. [online] www.w3schools.com. Available at: <https://www.w3schools.com/bootstrap5/bootstrap_forms.php> [Accessed 2 May 2025].
Anon. 2025. CSS Flexible Box Layout. [online] MDN Web Docs. Available at: <https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Flexible_Box_Layout> [Accessed 2 May 2025].
Anon. 2025. JavaScript DOM Events. [online] www.w3schools.com. Available at: <https://www.w3schools.com/js/js_htmldom_events.asp> [Accessed 4 May 2025].
Anon. 2025b. Microsoft.AspNetCore.Mvc 2.3.0. [online] Nuget.org. Available at: <https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc/> [Accessed 2 May 2025].
Anon. 2025c. Microsoft.EntityFrameworkCore.Sqlite 9.0.4. [online] Nuget.org. Available at: <https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/> [Accessed 2 May 2025].
ardalis, 2024. Overview of ASP.NET Core MVC. [online] Microsoft.com. Available at: <https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-9.0> [Accessed 3 May 2025].
aspnet, 2017. GitHub - aspnet/samples: Samples for ASP.NET Core. [online] GitHub. Available at: <https://github.com/aspnet/samples> [Accessed 3 May 2025].
ChatGPT, 2025a. ASP.NET Core MVC Login. [online] Chatgpt.com. Available at: <https://chatgpt.com/c/68220f7c-eafc-8010-88ec-3d20f9ccd525> [Accessed 2 May 2025].
ChatGPT, 2025b. ASP.NET Core MVC Setup. [online] Chatgpt.com. Available at: <https://chatgpt.com/c/68220f15-b8d8-8010-8d7a-e734e79669ec> [Accessed 2 May 2025].
ChatGPT, 2025c. Password Validation and Email Check. [online] Chatgpt.com. Available at: <https://chatgpt.com/c/68220f78-f0e4-8010-8794-8b6dd55ae1ba> [Accessed 2 May 2025].
ChatGPT, 2025d. Product Management System Implementation. [online] Chatgpt.com. Available at: <https://chatgpt.com/c/68220f7a-aa2c-8010-b92c-a0289da6d765> [Accessed 2 May 2025].
ChatGPT, 2025e. Session Management Debugging and Authorization Bug Fix. [online] Chatgpt.com. Available at: <https://chatgpt.com/c/68220f77-2444-8010-b618-e1b75615ec7d> [Accessed 3 May 2025].
contributors, M.O., Jacob Thornton, and Bootstrap, 2025. Cards. [online] getbootstrap.com. Available at: <https://getbootstrap.com/docs/5.2/components/card/> [Accessed 2 May 2025].
contributors, M.O., Jacob Thornton, and Bootstrap, 2025. Navbar. [online] getbootstrap.com. Available at: <https://getbootstrap.com/docs/5.2/components/navbar/> [Accessed 3 May 2025].
dotnet, 2014. aspnetcore/src/Mvc at main · dotnet/aspnetcore. [online] GitHub. Available at: <https://github.com/dotnet/aspnetcore/tree/main/src/Mvc> [Accessed 3 May 2025].
dotnet, 2022. Getting Started with Entity Framework Core [1 of 5] | Entity Framework Core for Beginners. [online] YouTube. Available at: <https://www.youtube.com/watch?v=SryQxUeChMc&list=PLdo4fOcmZ0oXCPdC3fTFA3Z79-eVH3K-s> [Accessed 2 May 2025].
freeCodeCamp.org, 2025. How to Build an ASP.NET Core MVC Web App – Tutorial. [online] YouTube. Available at: <https://www.youtube.com/watch?v=QtiM87MV27w> [Accessed 2 May 2025].
Milan Jovanović, 2024. Authentication made easy with ASP.NET Core Identity in .NET 8. [online] YouTube. Available at: <https://www.youtube.com/watch?v=S0RSsHKiD6Y> [Accessed 2 May 2025].
Net Ninja, 2021. Bootstrap 5 Crash Course Tutorial #14 - Working with Forms. [online] YouTube. Available at: <https://www.youtube.com/watch?v=dKVX22GR7zQ> [Accessed 2 May 2025].
Otto, M., 2022a. Forms. [online] Getbootstrap.com. Available at: <https://getbootstrap.com/docs/5.2/forms/overview/> [Accessed 3 May 2025].
Otto, M., 2022b. Pagination. [online] Getbootstrap.com. Available at: <https://getbootstrap.com/docs/5.2/components/pagination/> [Accessed 2 May 2025].
Rick-Anderson, 2024. Use cookie authentication without ASP.NET Core Identity. [online] Microsoft.com. Available at: <https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-9.0> [Accessed 3 May 2025].
Rick-Anderson, 2025. Getting Started - EF Core. [online] learn.microsoft.com. Available at: <https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli> [Accessed 3 May 2025].
tdykstra, 2024. Session in ASP.NET Core. [online] Microsoft.com. Available at: <https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0> [Accessed 3 May 2025].
W3Schools, 2019a. CSS Forms. [online] W3schools.com. Available at: <https://www.w3schools.com/css/css_form.asp> [Accessed 4 May 2025].
W3Schools, 2019b. HTML tables. [online] W3schools.com. Available at: <https://www.w3schools.com/html/html_tables.asp> [Accessed 4 May 2025].


