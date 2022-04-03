Create table tblDepartment_EF_Crud
(
 Id int primary key identity,
 Name nvarchar(50)
)

Insert into tblDepartment_EF_Crud values('IT')
Insert into tblDepartment_EF_Crud values('HR')
Insert into tblDepartment_EF_Crud values('Payroll')

Create table tblEmployee_EF_Crud
(
 EmployeeId int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DepartmentId int
)

Alter table tblEmployee_EF_Crud
add foreign key (DepartmentId)
references tblDepartment_EF_Crud(Id)

Insert into tblEmployee_EF_Crud values('Mark','Male','London',1)
Insert into tblEmployee_EF_Crud values('John','Male','Chennai',3)
Insert into tblEmployee_EF_Crud values('Mary','Female','New York',3)
Insert into tblEmployee_EF_Crud values('Mike','Male','Sydeny',2)
Insert into tblEmployee_EF_Crud values('Scott','Male','London',1)
Insert into tblEmployee_EF_Crud values('Pam','Female','Falls Church',2)
Insert into tblEmployee_EF_Crud values('Todd','Male','Sydney',1)
Insert into tblEmployee_EF_Crud values('Ben','Male','New Delhi',2)
Insert into tblEmployee_EF_Crud values('Sara','Female','London',1)