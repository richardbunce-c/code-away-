Use master
GO

Drop Database if Exists Projects

Create Database Projects

Use Projects
GO



Create Table Departments(
	DepartmentId int Identity Primary Key,
	DepartmentName nvarchar(25) not null,
	Constraint DeparmentNumber_check check (DepartmentId>0),
	)


	Create Table Projects(
	ProjectNumber int Identity Primary Key,
	ProjectName nvarchar(25)not null,
	StartDate date not null,
	)


Create Table Employees(
	EmployeeId int Identity Primary Key,
	JobTitle nvarchar(25) not null,
	LastName nvarchar(25) not null,
	FirstName nvarchar(25)not null,
	Gender nvarchar(10)null,
	DateOfBirth date not null,
	DateOfHire date not null,
	DepartmentId int not null,
	Constraint gender_check check ((gender='Male') or (gender='Female') or (gender='Other')),
	Constraint fk_Departments_Employees Foreign Key (DepartmentId) references Departments(DepartmentId)

)



		Insert into Departments (DepartmentName)
	                  Values ('Finance')
		Insert into Departments (DepartmentName)
	                  Values ('HR')
		Insert into Departments (DepartmentName)
	                  Values ('Distribution')
		Insert into Departments (DepartmentName)
	                  Values ('Management')
				


		Insert into Projects(ProjectName,StartDate)
		             Values('Washing Cash', '1987-06-14')
		Insert into Projects(ProjectName,StartDate)
		             Values('Whacking Guys', '1988-11-14')
		Insert into Projects(ProjectName,StartDate)
		             Values('Cooking', '1989-06-14')
		Insert into Projects(ProjectName,StartDate)
		             Values('Selling', '1990-06-14')

		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('El Chapo','Bunce','Richard','Male','1980-08-14','1981-08-14',4)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('El Nacho','Nacho','Supreme','Male','1981-08-14','1982-08-14',2)
				
