﻿Create Table Employees_TablePerHierarchy
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     AnuualSalary int,
     HourlyPay int,
     HoursWorked int,
     Discriminator nvarchar(50)
)

Insert into Employees_TablePerHierarchy values
('Mark', 'Hastings', 'Male', 60000, NULL, NULL, 'PermanentEmployee')
Insert into Employees_TablePerHierarchy values
('Steve', 'Pound', 'Male', NULL, 50, 160, 'ContractEmployee')
Insert into Employees_TablePerHierarchy values
('Ben', 'Hoskins', 'Male', NULL, 40, 120, 'ContractEmployee')
Insert into Employees_TablePerHierarchy values
('Philip', 'Hastings', 'Male', 45000, NULL, NULL, 'PermanentEmployee')
Insert into Employees_TablePerHierarchy values
('Mary', 'Lambeth', 'Female', 30000, NULL, NULL, 'PermanentEmployee')
Insert into Employees_TablePerHierarchy values
('Valarie', 'Vikings', 'Female', NULL, 30, 140, 'ContractEmployee')
Insert into Employees_TablePerHierarchy values
('John', 'Stanmore', 'Male', 80000, NULL, NULL, 'PermanentEmployee')