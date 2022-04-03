Create Table ManyToManyCourses
(
     CourseID int identity primary key,
     CourseName nvarchar(50)
)
GO

Create Table ManyToManyStudents
(
     StudentID int identity primary key,
     StudentName nvarchar(50)
)
GO

Create Table ManyToManyStudentCourses
(
     StudentID int not null foreign key references ManyToManyStudents(StudentID),
     CourseID int not null foreign key references ManyToManyCourses(CourseID)
     primary key (StudentID, CourseID)
)
GO

Insert into ManyToManyCourses values ('C#')
Insert into ManyToManyCourses values ('ASP.NET')
Insert into ManyToManyCourses values ('SQL Server')
Insert into ManyToManyCourses values ('WCF')
GO

Insert into ManyToManyStudents values ('Mike')
Insert into ManyToManyStudents values ('John')
GO

Insert into ManyToManyStudentCourses values (1, 1)
Insert into ManyToManyStudentCourses values (1, 2)
Insert into ManyToManyStudentCourses values (2, 1)
Insert into ManyToManyStudentCourses values (2, 2)
Insert into ManyToManyStudentCourses values (2, 3)
GO