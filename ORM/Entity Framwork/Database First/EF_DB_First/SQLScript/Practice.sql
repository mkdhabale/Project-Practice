Create table Departments
(
     ID int primary key identity,
     Name nvarchar(50),
     Location nvarchar(50)
)

Insert into Departments values ('IT', 'New York')
Insert into Departments values ('Admin', 'India')
Insert into Departments values ('HR', 'India')



Create table Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
	 Gender nvarchar(50),
     Salary int,
	 DepartmetnId int foreign key references Departments (ID)
)

Insert into Employees values ('Mark', 'MarkS','Male', 60000, 1)
Insert into Employees values ('Steve', 'SteveS','Male', 60000, 2)
Insert into Employees values ('Mary', 'MaryS','FeMale', 60000, 1)
