----Warning: This line should be uncommented if run within SSMS!!!
--Begin Tran
--Remove all the date from all tables in the DB
Delete from project_employee
Delete from employee
Delete from project
Delete from department
---Populate the tables with Test Data


--Department DData, add 2 departments
Insert department(name)
	values ('Department 1')
	Declare @dept1 int = @@identity

	Insert department(name)
	values ('Department 2')
	Declare @dept2 int = @@identity

--Add two employees, one in each department
Insert employee(department_id,first_name,last_name,job_title,birth_date,gender,hire_date)
	Values(@dept1, 'Billy', 'Emp1', 'Prince','2000-01-01','M','2019-03-01')
	Declare @emp1 int=@@identity

	Insert employee(department_id,first_name,last_name,job_title,birth_date,gender,hire_date)
	Values(@dept2, 'Joanie', 'Emp2', 'Princess','2000-01-01','F','2019-03-01')
	Declare @emp2 int=@@identity

	--Add two projects
	Insert project(name,from_date,to_date)
	Values('Proj1', '2010-01-01','2015-01-01')
	Declare @proj1 int=@@identity

	Insert project(name,from_date,to_date)
	Values('Proj2', '2010-02-02','2015-02-02')
	Declare @proj2 int=@@identity

	--Associate emps/projs
	Insert project_employee(project_id,employee_id)
Values(@proj1, @emp1),
(@proj1, @emp2),
(@proj2, @emp2)

---Warning:This line should be uncommented if run within ssms!!!
Select * from project_employee
Select * from employee
Select * from project
Select * from department

--Rollback Tran