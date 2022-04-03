
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/18/2022 19:49:42
-- Generated from EDMX file: D:\GIT_WORKSPACE\Mukul\Entity Framwork\Model First\EF_Model_First\Model\EmployeeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mukul_DND];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[Employees]
    ([DepartmentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------




Insert into Departments values ('IT', 'New York')
Insert into Departments values ('Admin', 'India')
Insert into Departments values ('HR', 'India')

Insert into Employees values ('Mark', 'MarkS','Male', 60000, 1)
Insert into Employees values ('Steve', 'SteveS','Male', 60000, 2)
Insert into Employees values ('Mary', 'MaryS','FeMale', 60000, 1)





Insert into Departments values ('IT', 'New York')
Insert into Departments values ('Admin', 'India')
Insert into Departments values ('HR', 'India')

Insert into Employee values ('Mark', 'MarkS','Male', 60000, 1)
Insert into Employee values ('Steve', 'SteveS','Male', 60000, 2)
Insert into Employee values ('Mary', 'MaryS','FeMale', 60000, 1)


ALter table Employees
add address1 varchar(50)

select * from Employee
select * from Departments

drop table Employees
drop table Departments

ALTER TABLE Employees
DROP COLUMN LastName;

use Mukul_CF_DND


drop database Mukul_CF_DND


select * from [dbo].[__MigrationHistory]

ALter table Employee
add JobTitle varchar(50)