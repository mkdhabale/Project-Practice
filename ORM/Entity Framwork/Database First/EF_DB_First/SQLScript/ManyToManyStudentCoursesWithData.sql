




Create Table ManyToManyCoursesWithData
(
     CourseID int identity primary key,
     CourseName nvarchar(50)
)
GO

Create Table ManyToManyStudentsWithData
(
     StudentID int identity primary key,
     StudentName nvarchar(50)
)
GO

Create Table ManyToManyStudentCoursesWithData
(
     StudentID int not null foreign key references ManyToManyStudentsWithData(StudentID),
     CourseID int not null foreign key references ManyToManyCoursesWithData(CourseID),
     EnrolledDate DateTime,
     primary key (StudentID, CourseID)
)
GO

Insert into ManyToManyCoursesWithData values ('C#')
Insert into ManyToManyCoursesWithData values ('ASP.NET')
Insert into ManyToManyCoursesWithData values ('SQL Server')
Insert into ManyToManyCoursesWithData values ('WCF')
GO

Insert into ManyToManyStudentsWithData values ('Mike')
Insert into ManyToManyStudentsWithData values ('John')
GO

Insert into ManyToManyStudentCoursesWithData values (1, 1, Getdate())
Insert into ManyToManyStudentCoursesWithData values (1, 2, Getdate())
Insert into ManyToManyStudentCoursesWithData values (2, 1, Getdate())
Insert into ManyToManyStudentCoursesWithData values (2, 2, Getdate())
Insert into ManyToManyStudentCoursesWithData values (2, 3, Getdate())
GO