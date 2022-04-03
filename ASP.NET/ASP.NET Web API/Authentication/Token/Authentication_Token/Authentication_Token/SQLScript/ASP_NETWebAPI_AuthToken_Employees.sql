Create table ASP_NETWebAPI_AuthToken_Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
)
Go

Insert into ASP_NETWebAPI_AuthToken_Employees values ('Mark', 'Hastings', 'Male', 60000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('Steve', 'Pound', 'Male', 45000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('Philip', 'Hastings', 'Male', 45000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('Mary', 'Lambeth', 'Female', 30000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('Valarie', 'Vikings', 'Female', 35000)
Insert into ASP_NETWebAPI_AuthToken_Employees values ('John', 'Stanmore', 'Male', 80000)
Go