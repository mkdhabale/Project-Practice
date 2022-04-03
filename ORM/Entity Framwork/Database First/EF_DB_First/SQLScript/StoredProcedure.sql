Create table Employees_StoredProcedure
(
     ID int primary key identity,
     Name nvarchar(50),
     Gender nvarchar(50),
     Salary int
)

Insert into Employees_StoredProcedure values ('Mark', 'Male', 60000)
Insert into Employees_StoredProcedure values ('Steve', 'Male', 45000)
Insert into Employees_StoredProcedure values ('Ben', 'Male', 70000)
Insert into Employees_StoredProcedure values ('Philip', 'Male', 45000)
Insert into Employees_StoredProcedure values ('Mary', 'Female', 30000)
Insert into Employees_StoredProcedure values ('Valarie', 'Female', 35000)
Insert into Employees_StoredProcedure values ('John', 'Male', 80000)


Go;
Create procedure InsertEmployee_StoredProcedure
@Name nvarchar(50),
@Gender nvarchar(50),
@Salary int
as
Begin
     Insert into Employees_StoredProcedure values (@Name, @Gender, @Salary)   
End
Go

Create procedure UpdateEmployee_StoredProcedure
@ID int,
@Name nvarchar(50),
@Gender nvarchar(50),
@Salary int
as
Begin
     Update Employees_StoredProcedure Set Name = @Name, Gender = @Gender,
     Salary = @Salary
     where ID = @ID
End
Go

Create procedure DeleteEmployee_StoredProcedure
@ID int
as
Begin
     Delete from Employees_StoredProcedure where ID = @ID
End
Go

