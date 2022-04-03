Create Table Employees_TablePerType
(
     EmployeeID int primary key,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
)
GO

Create Table PermanentEmployees_TablePerType
(
     EmployeeID int foreign key references
     Employees_TablePerType(EmployeeID) not null,
     AnnualSalary int
)
GO

Create Table ContractEmployees_TablePerType
(
     EmployeeID int foreign key references
     Employees_TablePerType(EmployeeID) not null,
     HourlyPay int,
     HoursWorked int
)
GO

-- Employees_TablePerType Table Insert
Insert into Employees_TablePerType values (1, 'Mark', 'Hastings', 'Male')
Insert into Employees_TablePerType values (2, 'Steve', 'Pound', 'Male')
Insert into Employees_TablePerType values (3, 'Ben', 'Hoskins', 'Male')
Insert into Employees_TablePerType values (4, 'Philip', 'Hastings', 'Male')
Insert into Employees_TablePerType values (5, 'Mary', 'Lambeth', 'Female')
Insert into Employees_TablePerType values (6, 'Valarie', 'Vikings', 'Female')
Insert into Employees_TablePerType values (7, 'John', 'Stanmore', 'Male')

-- PermanentEmployees_TablePerType Table Insert
Insert into PermanentEmployees_TablePerType values (1, 60000)
Insert into PermanentEmployees_TablePerType values (3, 45000)
Insert into PermanentEmployees_TablePerType values (4, 30000)
Insert into PermanentEmployees_TablePerType values (7, 80000)

-- ContractEmployees_TablePerType Table Insert
Insert into ContractEmployees_TablePerType values (2, 50, 160)
Insert into ContractEmployees_TablePerType values (5, 40, 120)
Insert into ContractEmployees_TablePerType values (6, 30, 140)
