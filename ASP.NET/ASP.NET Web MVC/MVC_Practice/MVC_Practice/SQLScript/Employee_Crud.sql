Create table Employee_Crud
(
 ID int identity primary key,
 Name nvarchar(50),
 Gender nvarchar(10),
 Email nvarchar(50)
)

Insert into Employee_Crud values('Sara Nani', 'Female', 'Sara.Nani@test.com')
Insert into Employee_Crud values('James Histo', 'Male', 'James.Histo@test.com')
Insert into Employee_Crud values('Mary Jane', 'Female', 'Mary.Jane@test.com')
Insert into Employee_Crud values('Paul Sensit', 'Male', 'Paul.Sensit@test.com')