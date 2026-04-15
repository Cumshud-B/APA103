create database Company 
use Company 

create table Employees (
EmployeeID int,
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(25),
PhoneNumber int,
HireDate date,
JobTitle nvarchar(50),
Salary money,
Departament Nvarchar(50)
)

INSERT INTO Employees VALUES
(1, 'Ali', 'Mammadov', 'ali@mail.com', 501234567, '2020-05-10', 'Developer', 1500, 'IT'),
(2, 'Nigar', 'Aliyeva', 'nigar@mail.com', 502345678, '2021-03-15', 'HR Specialist', 1200, 'HR'),
(3, 'Kamran', 'Huseynov', 'kamran@mail.com', 503456789, '2019-07-20', 'Manager', 2500, 'Management'),
(4, 'Aysel', 'Rahimova', 'aysel@mail.com', 504567890, '2022-01-05', 'Accountant', 1300, 'Finance'),
(5, 'Orxan', 'Ismayilov', 'orxan@mail.com', 505678901, '2018-11-11', 'Designer', 1400, 'Design'),
(6, 'Leyla', 'Quliyeva', 'leyla@mail.com', 506789012, '2023-06-25', 'Tester', 1100, 'IT');

select * from Employees 

select * from Employees where Salary > 2000

select * from Employees where Departament = 'IT'

select * from Employees order by Salary desc

select FirstName , Salary from Employees

select * from Employees where HireDate > '01-01-2020'

select * from Employees where Email like '%li%'

select max(Salary) as MaxSalary from Employees 

select min(Salary) as MinSalary from Employees 

select AVG(Salary) as Maas from Employees 

select COUNT(EmployeeID) as IsciSayi from Employees 

select sum(Salary) as Cem from Employees

update Employees set [Salary] = 2800 where EmployeeID = 1

update Employees set Salary = Salary *1.1

update Employees set [JobTitle] = '"HR Meneceri' where EmployeeID =2

delete Employees  where EmployeeID = 5

delete Employees where Salary > 1500

select * from Employees where FirstName like '%a%'

select * from  Employees where Salary between 1200 and 1400

select * from Employees where Departament in ('IT','HR')




