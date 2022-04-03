Create table Employees_SelfReferencing
(
     EmployeeID int primary key identity,
     EmployeeName nvarchar(50),
     ManagerID int foreign key references Employees_SelfReferencing(EmployeeID)
)
GO

Insert into Employees_SelfReferencing values ('John', NULL)
Insert into Employees_SelfReferencing values ('Mark', NULL)
Insert into Employees_SelfReferencing values ('Steve', NULL)
Insert into Employees_SelfReferencing values ('Tom', NULL)
Insert into Employees_SelfReferencing values ('Lara', NULL)
Insert into Employees_SelfReferencing values ('Simon', NULL)
Insert into Employees_SelfReferencing values ('David', NULL)
Insert into Employees_SelfReferencing values ('Ben', NULL)
Insert into Employees_SelfReferencing values ('Stacy', NULL)
Insert into Employees_SelfReferencing values ('Sam', NULL)
GO

Update Employees_SelfReferencing Set ManagerID = 8 Where EmployeeName IN ('Mark', 'Steve', 'Lara')
Update Employees_SelfReferencing Set ManagerID = 2 Where EmployeeName IN ('Stacy', 'Simon')
Update Employees_SelfReferencing Set ManagerID = 3 Where EmployeeName IN ('Tom')
Update Employees_SelfReferencing Set ManagerID = 5 Where EmployeeName IN ('John', 'Sam')
Update Employees_SelfReferencing Set ManagerID = 4 Where EmployeeName IN ('David')
GO