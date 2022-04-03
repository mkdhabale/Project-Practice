Create table EmployeesConditionalMapping
(
     EmployeeID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     IsTerminated bit not null
)
GO

Insert into EmployeesConditionalMapping values ('Mark', 'Hastings', 'Male', 0)
Insert into EmployeesConditionalMapping values ('Steve', 'Pound', 'Male', 0)
Insert into EmployeesConditionalMapping values ('Ben', 'Hoskins', 'Male', 0)
Insert into EmployeesConditionalMapping values ('Philip', 'Hastings', 'Male', 1)
Insert into EmployeesConditionalMapping values ('Mary', 'Lambeth', 'Female', 0)
Insert into EmployeesConditionalMapping values ('Valarie', 'Vikings', 'Female', 0)
Insert into EmployeesConditionalMapping values ('John', 'Stanmore', 'Male', 1)