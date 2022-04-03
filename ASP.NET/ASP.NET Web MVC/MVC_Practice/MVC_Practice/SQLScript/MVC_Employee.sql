create table MVC_Employee
(
EmployeeId int identity primary key,
Name varchar(200),
Gender varchar(200),
City varchar(200),
)

insert into MVC_Employee(Name, Gender, City) 
values('Mukul', 'Male', 'Ahmedabad'), ('Mukul1', 'Male', 'Ahmedabad1')