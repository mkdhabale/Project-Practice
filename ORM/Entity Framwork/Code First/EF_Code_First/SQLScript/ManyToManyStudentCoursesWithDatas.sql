-- Insert into Courses Table
Insert into ManyToManyCoursesWithDatas values ('C#')
Insert into ManyToManyCoursesWithDatas values ('ASP.NET')
Insert into ManyToManyCoursesWithDatas values ('SQL Server')
Insert into ManyToManyCoursesWithDatas values ('WCF')
GO

-- Insert into Students Table
Insert into ManyToManyStudentsWithDatas values ('Mike')
Insert into ManyToManyStudentsWithDatas values ('John')
GO

-- Insert into StudentCourses Table
Insert into ManyToManyStudentCoursesWithDatas values (1, 1, Getdate())
Insert into ManyToManyStudentCoursesWithDatas values (1, 2, Getdate())
Insert into ManyToManyStudentCoursesWithDatas values (2, 1, Getdate())
Insert into ManyToManyStudentCoursesWithDatas values (2, 2, Getdate())
Insert into ManyToManyStudentCoursesWithDatas values (2, 3, Getdate())
GO