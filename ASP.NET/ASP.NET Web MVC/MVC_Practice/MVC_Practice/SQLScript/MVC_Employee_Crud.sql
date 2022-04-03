Create table tblEmployee_Crud
(
 Id int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DateOfBirth DateTime
)

Insert into tblEmployee_Crud values('Mark','Male','London','01/05/1979')
Insert into tblEmployee_Crud values('John','Male','Chennai','03/07/1981')
Insert into tblEmployee_Crud values('Mary','Female','New York','02/04/1978')
Insert into tblEmployee_Crud values('Mike','Male','Sydeny','02/03/1974')
Insert into tblEmployee_Crud values('Scott','Male','London','04/06/1972')
go

Create procedure spGetAllEmployees_Crud
as
Begin
 Select Id, Name, Gender, City, DateOfBirth
 from tblEmployee_Crud
End
go



Create procedure spAddEmployee_Crud
@Name nvarchar(50),  
@Gender nvarchar (10) = null,  
@City nvarchar (50),  
@DateOfBirth DateTime  = null 
as  
Begin  
 Insert into tblEmployee_Crud (Name, Gender, City, DateOfBirth)  
 Values (@Name, @Gender, @City, @DateOfBirth)  
End
go

Create procedure spSaveEmployee_Crud  
@Id int,
@Name nvarchar(50),      
@Gender nvarchar (10),      
@City nvarchar (50),      
@DateOfBirth DateTime 
as      
Begin      
 Update tblEmployee_Crud Set
 Name = @Name,
 Gender = @Gender,
 City = @City,
 DateOfBirth = @DateOfBirth
 Where Id = @Id 
End
go


Create procedure spDeleteEmployee_Crud  
@Id int
as
Begin
 Delete from tblEmployee_Crud 
 where Id = @Id
End