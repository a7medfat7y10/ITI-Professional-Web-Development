USE Company_SD

--1
Select D.Dependent_name, D.Sex from Dependent D 
inner join Employee E ON D.ESSN = E.SSN and E.Sex = 'F' and D.Sex = 'F'
UNION 
Select D.Dependent_name, D.Sex from Dependent D 
inner join Employee E ON D.ESSN = E.SSN and E.Sex = 'M' and D.Sex = 'M'

--2
Select Project.Pname, sum(Works_for.Hours) * 7 from Project inner join Works_for ON Project.Pnumber = Works_for.Pno group by Project.Pname  

--3
select Departments.* from Departments inner join Employee On Departments.Dnum = Employee.Dno where Employee.SSN = (Select min(SSN) From Employee)

--4
select Departments.Dname, max(isnull(Employee.Salary, 0)) as Maximum ,
		min(isnull(Employee.Salary, 0)) as Minimum, AVG(isnull(Employee.Salary, 0)) From Departments 
inner join Employee ON Employee.Dno = Departments.Dnum
group by Departments.Dname

--5
Select distinct (Employee.Fname + ' ' + Employee.Lname) as Fullname from Employee inner join Departments ON Departments.MGRSSN = Employee.SSN 
inner join Dependent ON Departments.MGRSSN not in(Select ESSN from Dependent) 

--6
select Departments.Dnum, Departments.Dname, count(Employee.SSN) as count from Departments inner join Employee ON Employee.Dno = Departments.Dnum 
Group by Departments.Dnum, Departments.Dname 
having avg(isnull(Employee.Salary, 0)) < (Select avg(isnull(Employee.Salary, 0)) from Employee)

--7	--
select Fname+' '+Lname as Fullname , Pname from Employee E , Works_for W , Project P 
where E.SSN = W.ESSn and P.Pnumber = W.Pno
order by P.Dnum , Lname ASC , Fname  ASC

--8
Select max(Salary) as Maximum,
		(Select max(Salary) from Employee where Salary not in (Select max(Salary) from Employee)) as Second_Max 
from Employee 

--9
Select (Employee.Fname + ' ' + Employee.Lname)as fullname from Employee, Dependent 
where (Employee.Fname + ' ' + Employee.Lname) Like Dependent.Dependent_name

--10
Select Employee.SSN, (Employee.Fname + ' ' + Employee.Lname)as fullname from Employee where exists (Select Dependent.Dependent_name from Dependent)

--11
Insert Into Departments Values('Dept IT', 100, 112233, '1/11/2006' )

--12
Update Departments set MGRSSN = 968574 where Dnum = 100
Update Departments set MGRSSN = 102672 where Dnum = 20
Update Employee set Dno = 20 where SSN = 102672
Update Employee set Dno = 100 where SSN = 968574
Update Employee set Superssn = 102672 where SSN = 102672

--13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so 
--try to delete his data from your database in case you know that 
Update Employee set Superssn = 102672 where Superssn = 223344
Delete From Dependent Where ESSN = 223344
Delete From Works_for where ESSn = 223344
Update Departments Set MGRSSN = 102672 where MGRSSN = 223344
delete from Employee where SSN = 223344


--14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
 update Employee set Salary= Salary*1.3 
 from Employee, Works_for , Project
 where Employee.SSN = Works_for.ESSn and Project.Pnumber=Works_for.Pno and Pname='Al Rabwah'


