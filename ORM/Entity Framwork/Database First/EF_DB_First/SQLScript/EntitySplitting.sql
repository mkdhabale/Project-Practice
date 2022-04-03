Create table Employees_EntitySplitting
(
     EmployeeID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50)
)
GO

Create table EmployeeContactDetails_EntitySplitting
(
     EmployeeID int primary key,
     Email nvarchar(50),
     Mobile nvarchar(50),
     LandLine nvarchar(50),
	 CONSTRAINT fk_pk_empid FOREIGN KEY(EmployeeID) REFERENCES Employees_EntitySplitting(EmployeeID)
)
GO

Insert into Employees_EntitySplitting values ('Mark', 'Hastings', 'Male')
Insert into Employees_EntitySplitting values ('Steve', 'Pound', 'Male')
Insert into Employees_EntitySplitting values ('Ben', 'Hoskins', 'Male')
Insert into Employees_EntitySplitting values ('Philip', 'Hastings', 'Male')
Insert into Employees_EntitySplitting values ('Mary', 'Lambeth', 'Female')

Insert into EmployeeContactDetails_EntitySplitting values
(1, 'Mark@pragimtech.com', '111111111', '111111111')
Insert into EmployeeContactDetails_EntitySplitting values
(2, 'Steve@pragimtech.com', '2222222222', '2222222222')
Insert into EmployeeContactDetails_EntitySplitting values
(3, 'Ben@pragimtech.com', '3333333333', '3333333333')
Insert into EmployeeContactDetails_EntitySplitting values
(4, 'Philip@pragimtech.com', '44444444444', '44444444444')
Insert into EmployeeContactDetails_EntitySplitting values
(5, 'Mary@pragimtech.com', '5555555555', '5555555555')
