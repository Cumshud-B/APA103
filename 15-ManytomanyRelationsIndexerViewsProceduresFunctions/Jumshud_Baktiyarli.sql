create database CompanyMMM
use CompanyMMM

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL CHECK (DATEDIFF(YEAR, BirthDate, GETDATE()) >= 18),
    Email NVARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY,
    ProjectName NVARCHAR(100) NOT NULL UNIQUE,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    CHECK (EndDate >= StartDate)
);

CREATE TABLE EmployeeProjects (
EmployeeID int foreign key references Employees(EmployeeID),
ProjectID int foreign key references Projects(ProjectID),
AssignedDate date
);

INSERT INTO Employees (FirstName, LastName, BirthDate, Email)
VALUES
('Ali', 'Aliyev', '1995-05-10', 'ali@mail.com'),
('Aysel', 'Huseynova', '1998-03-12', 'aysel@mail.com'),
('Orxan', 'Mammadov', '1992-07-20', 'orxan@mail.com'),
('Nigar', 'Rustamova', '1996-11-01', 'nigar@mail.com'),
('Elvin', 'Quliyev', '1993-09-15', 'elvin@mail.com');


INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES
('Website', '2024-01-01', '2024-06-01'),
('Mobile App', '2024-02-01', '2024-07-01'),
('ERP System', '2024-03-01', '2024-05-05');


INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
VALUES
(1, 1, '2024-01-05'),
(2, 1, '2024-01-10'),
(3, 2, '2024-02-15'),
(4, 2, '2024-02-20'),
(5, 3, '2024-03-10'),
(1, 3, '2024-03-12');


select * from Employees

select * from Projects

select e.FirstName,e.LastName,p.ProjectName from Employees e
join EmployeeProjects ep
on e.EmployeeID = ep.EmployeeID
join Projects p
on ep.EmployeeID = p.ProjectID


SELECT p.ProjectName,COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
JOIN EmployeeProjects ep 
ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectName;



SELECT  p.ProjectName,COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
JOIN EmployeeProjects ep 
ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectName
HAVING COUNT(ep.EmployeeID) > 1;



CREATE VIEW EmployeeProjectView
AS
SELECT e.EmployeeID,e.FirstName,e.LastName,p.ProjectID,p.ProjectName,ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep 
ON e.EmployeeID = ep.EmployeeID
JOIN Projects p 
ON p.ProjectID = ep.ProjectID;


select * from EmployeeProjectView





CREATE PROCEDURE sp_AssignEmployeeToProject
@empId INT,
@projId INT
AS BEGIN 
IF NOT EXISTS (
SELECT 1
FROM EmployeeProjects
WHERE EmployeeID = @empId AND ProjectID = @projId
    )
    BEGIN
    INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
    VALUES (@empId, @projId, GETDATE())
    END
END






CREATE FUNCTION fn_GetProjectCount (@empId INT)
RETURNS INT
AS
BEGIN
DECLARE @count INT;
SELECT @count = COUNT(*)
FROM EmployeeProjects
WHERE EmployeeID = @empId;
RETURN @count;
END

SELECT dbo.fn_GetProjectCount(1) AS ProjectCount;


EXEC sp_AssignEmployeeToProject 1, 2;



DELETE FROM EmployeeProjects
WHERE EmployeeID = 1;