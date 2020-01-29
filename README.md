====================================================

Rules:

·        Please keep track of the time you spend for each task.

·        Please create all of the necessary components within a single Visual Studio solution. Make sure it builds.

·        Use appropriate naming conventions and keep coding standards consistent across the solution.

·        Read the entire email before starting.

·        You can use any resource to help you as long as you list the resource in task 4.

·        All code is to be handed to us through a public or private GitHub repository. Please do not send us zip files.

·        Do not place "OneBit" in the name of the solution, so you can use your project as a reference in future.

·        You can use any version of libraries and tools.

 

 

Overview:

Your task is to create an ASP.NET web project which loads data from a database into a grid. You are required to create Customer and Purchase Order entities, then visualise them in forms and grids. You are required to demonstrate that you can handle databases, data access, layered architectures and web presentation. You are free to make design decisions as you see fit, however we require you to explain your decisions and rationale in Task 4.

 

Task 1.

Create a Microsoft SQL database and a table which will store the following contact information :

 

Customers Table:

First Name

Last Name

Sex (male/female)

Telephone

Created (DateTime)

Status (active/inactive/deleted)

 

Purchase Orders Table:

Description

Price

Quantity

Total Amount

Created (DateTime)

Status (active/inactive/deleted)

 

Relationships must exist between the Customer and Purchase Order objects. In the future, there is a requirement that you will need to search purchase orders by their description, but you are not required to implement this requirement now.

 

Name the database, tables and columns as you see fit. Add any fields you require in order to complete the relationship. Use column types as you see fit. The status column should contain whether the item is active, inactive or deleted. Use any SQL database. You may choose to use Code First or Database First database design strategies.

 

Task 2.

Create a project containing your data access layer (if you have not used one already for creating your database). Implement methods for CRUD operations to your tables. You may use any ORM to extract and transform the data within the database. Make use of a Service layer and follow good OOP practices. You can use any architectural design concept or project structure you choose, as long as you can explain why and what features it brings you.

  

Task 3.

Create an ASP.NET Core web project including the minimal set of components you need to complete the following:

 

1.       Visualise the Customer data contained in the database in a grid/table format.

a.       Only non-deleted items should be shown

b.      The grid should have an activate/deactivate item option (and it should be apparent which items are active and which are inactive)

c.       The grid should have a delete item link

·       When viewing a Customer, show a grid with the relevant purchase orders. This could be inline or on a new page. The same rules for deleted and active results must be applied.

2.        The grid should have paging and the ability to sort by each column.

3.        Create New and Edit forms to be able to add and edit rows.

 

You can use any mix of client-side and backend technologies, but stick to ASP.NET Core for the server-side. Feel free to reuse anything to style the page, grid and forms.

 

Bonus points if the grid is loaded asynchronously and data passed through API action methods

Bonus points if the page looks presentable

Bonus points if you deploy your solution to a free Azure App Service

 

Task 4.

This task is to be submitted in English and via e-mail. Explain the reasons why you have chosen the database and schema creation method. Explain how you created the relationships. Explain the structure of your data access layer and anything that you have done to make the design better. Explain how your grids bind to data. Explain anything else you feel is valuable and constructive regarding the solution. List all links, reading material and resources you have used to help you in your development. Provide details of the time you have spent on each task.

 

At the end:

·        Give us a link to the GitHub repository with your submission.

·        If you have any commentary or questions, please keep them in English and my e-mail.

·        As detailed in Task 4, please include references to the resources that you have used for guidance in achieving the tasks.

===============================================================================
