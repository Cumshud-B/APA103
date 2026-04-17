create database Companyyy
use Companyyy 

create table Cuontries(
Id int Primary key identity,
Name nvarchar(50) not null
)

create table Cities(
Id int Primary key identity,
Name nvarchar(50) not null,
CountryId int  foreign key references Cuontries(Id)
)

create table Employees(
Id int Primary key identity,
Name nvarchar(50) not null,
Surname nvarchar(50) not null,
Age int,
Salary money,
Position nvarchar(50),
IsDeleted bit,
CityId int,
foreign key (CityId)references  Cities(Id)
)



INSERT INTO Cuontries(Name)
VALUES 
('Azerbaijan'),
('Turkey'),
('Germany');

INSERT INTO Cities (Name, CountryId)
VALUES
('Baku', 1),
('Ganja', 1),
('Istanbul', 2),
('Berlin', 3);

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId)
VALUES
('Ali', 'Aliyev', 25, 1200, 'Reseption', 0, 1),
('Veli', 'Memmedov', 30, 1500, 'Manager', 0, 1),
('Ayse', 'Yilmaz', 28, 1300, 'Designer', 1, 3),
('John', 'Doe', 35, 2000, 'Engineer', 1, 4);



select e.Name ,e.Surname ,c.Name,cu.Name 
from Employees as e
join Cities as c
on CityId = c.Id 
join Cuontries as cu
on CountryId = cu.Id  


select e.Name ,e.Surname ,c.Name,cu.Name 
from Employees as e
join Cities as c
on CityId = c.Id 
join Cuontries as cu
on CountryId = cu.Id 
where e.Salary > 1300


select c.Name ,cu.Name  from Cities c
join Cuontries cu
on CountryId= cu.Id 


select e.Age ,e.CityId ,e.IsDeleted ,e.Name,e.Position,e.Salary,e.Surname    from Employees e 
where e.Id = 1


select e.Name ,e.Surname ,c.Name,cu.Name 
from Employees as e
join Cities as c
on CityId = c.Id 
join Cuontries as cu
on CountryId = cu.Id  
where e.IsDeleted = 1

