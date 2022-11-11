Use Company_SD

----1
select Departments.Dnum, Departments.Dname, Employee.SSN, (Employee.Fname + Employee.Lname) as FullName 
from Departments inner join Employee ON Departments.MGRSSN = Employee.SSN

----2
select Departments.Dname, Project.Pname from Departments inner join Project ON  Departments.Dnum = Project.Dnum

----3
select * from Dependent inner join Employee ON Employee.SSN = Dependent.ESSN

----4	Display the Id, name and location of the projects in Cairo or Alex city.
select Pnumber, Pname, Plocation from Project where City = 'Cairo' or  City = 'Alex'

----5
select * from Project where Pname Like 'a%'

----6
select * from Employee where Dno = 30 and Salary between 1000 and 2000

----7
select (Employee.Fname + '' + Employee.Lname) as FullName from Employee inner join Works_for ON Employee.Dno = 10 and Works_for.Hours >= 10 
Inner join Project On Project.Pname = 'Al Rabwah' and Works_for.Pno = Project.Pnumber

----8
select E.Fname+E.Lname from Employee E, Employee S where E.Superssn = S.SSN and S.Fname = 'Kamel' and S.Lname = 'Mohamed'

----9
select (Employee.Fname + ' ' + Employee.Lname) as FullName, Project.Pname from Employee 
inner join Works_for ON Works_for.ESSn = Employee.SSN 
inner Join Project ON Project.Pnumber = Works_for.Pno
Order By Project.Pname ASC

----10--
select Project.Pnumber, Departments.Dname, Employee.Lname, Employee.Address, Employee.Bdate from Project
inner join Departments On Departments.Dnum = Project.Dnum 
inner join Employee On Employee.SSN = Departments.MGRSSN 
where Project.City = 'Cairo'

---11
Select * from Employee inner join Departments On Departments.MGRSSN = Employee.SSn

---12
Select Employee.*, Dependent.* from Employee Left Outer Join Dependent ON Employee.SSN = Dependent.ESSN

--13
Insert  into Employee (Fname, Lname, Dno, SSN,  Superssn , Salary) VALUES ('Ahmed','Fathy',30, 102672,112233, 3000)
----14
Insert  into Employee (Fname, Lname, Dno, SSN) VALUES ('Mohamed','Refaat',30, 102660)

----15
UPDATE Employee SET Salary += .2 * Salary WHERE Employee.Lname ='Fathy' 