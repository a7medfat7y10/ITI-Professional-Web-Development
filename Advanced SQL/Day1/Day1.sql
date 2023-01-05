Use SD
---1.Department Table
create table Department
(
	DeptNo varchar(50) primary key,
	DeptName varchar(50),
	Location loc
)

-----Employee table
create table Employee 
(
	EmpNo varchar(50),
	EmpFname varchar(50) not null,
	EmpLname varchar(50) not null,
	DeptNo varchar(50),
	Salary int,
	constraint c1 primary key(EmpNo),
	constraint c2 unique(Salary),
	constraint c3 foreign key(DeptNo) references Department(DeptNo)
      on delete set NULL on update cascade
)

--Rule Employee
create rule r1 as @x<6000
sp_bindrule r1,'Employee.Salary'

----Data type rule Department
sp_addtype loc,'nchar(2)'  

create rule r2 as @y in('NY','DS','KW')

create default def1 as 'NY'

sp_bindrule r2,loc

sp_bindefault def1,loc


----testing referential

insert into Works_on values(11111 ,'p1', 'Manager', '2013.1.1') --error

select * from Works_on

update Works_on
set EmpNo=10102  where EmpNo=11111

UPDATE	HR.Employee 
set EmpNo= 22222 where EmpNo=10102

delete from HR.Employee where EmpNo=10102


----table modification
alter table HR.Employee add TelephoneNumber int  

alter table HR.Employee drop column TelephoneNumber



---2.schema creation
create schema HR

create schema Company

alter schema HR transfer Employee

alter schema Company transfer Department


-----3.
sp_help 'HR.Employee'

---4.synonym
create synonym Emp for HR.Employee

Select * from Employee
Select * from [HR].Employee
Select * from Emp
Select * from [HR].Emp


-----5.
Update Company.Project set Budget +=(.10 * Budget) from Company.Project inner join Works_on 
ON  Works_on.ProjectNo = Company.Project.ProjectNo and Works_on.EmpNo = 10102

-----6.
update Company.Department
set DeptName='sales'
from Company.Department d inner join HR.Employee  e on e.DeptNo=d.DeptNo
where e.EmpFname ='james';


-----7
update Works_on
set Enter_Date ='12.12.2007'
from Works_on w inner join HR.Employee e on w.EmpNo=e.EmpNo
inner join Company.Department d on d.DeptNo=e.DeptNo
where d.DeptName='sales'


-----8
delete from Works_on 
where EmpNo IN
(select e.EmpNo
from HR.Employee e inner join Company.Department d on d.DeptNo=e.DeptNo)

