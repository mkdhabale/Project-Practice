-- Insert into Courses Table
Insert into ManyToManyCourses values ('C#')
Insert into ManyToManyCourses values ('ASP.NET')
Insert into ManyToManyCourses values ('SQL Server')
Insert into ManyToManyCourses values ('WCF')
GO

-- Insert into Students Table
Insert into ManyToManyStudents values ('Mike')
Insert into ManyToManyStudents values ('John')
GO

-- Insert into StudentCourses Table
Insert into ManyToManyStudentCourses values (1, 1)
Insert into ManyToManyStudentCourses values (1, 2)
Insert into ManyToManyStudentCourses values (2, 1)
Insert into ManyToManyStudentCourses values (2, 2)
Insert into ManyToManyStudentCourses values (2, 3)
GO