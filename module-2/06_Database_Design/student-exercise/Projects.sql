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
	Constraint fk_Employees_Departments Foreign Key (DepartmentId) references Departments(DepartmentId)

)
Create Table EmployeesProjects(
	ProjectNumber int ,
	EmployeeId int,
	Constraint pk_EmpoyeesProjects Primary Key (ProjectNumber, EmployeeId),
	Constraint fk_EmployeesProjects_Projects foreign key (ProjectNumber) references Projects(ProjectNumber),
	Constraint fk_EmployeesProjects_Employees foreign key (EmployeeId) references Employees(EmployeeId)
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
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('El Kabong','Chipotle','Chiquita','Female','1985-01-24','1983-08-14',4)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
					 Values('El Tequila','Fuego','Peter','Male','1984-11-28','1984-08-14',1)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('La Casa','Gigante','Sasquatch','Male','1989-05-22','1985-08-14',1)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('La Prima','Bonita','Lita','Female','1988-03-01','1986-08-14',3)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
		             Values('Speedy','Gonzalez','Speedy','Male','1999-12-11','2000-08-14',2)
		Insert into Employees(JobTitle, LastName, FirstName, Gender, DateOfBirth, DateOfHire,DepartmentId)
					 Values('La Gringa','Smith','Jane','Other','1988-08-16','1989-08-14',3)


