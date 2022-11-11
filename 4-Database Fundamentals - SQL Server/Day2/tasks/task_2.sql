use Company_SD

-----1
select * from Employee

----2
select FName, LName, Salary, Dno from Employee

----3
select Pname, Pnumber, Dnum from Project

----4
select (Fname + Lname) as FullName , .10 * (12 * Salary) as Annual_Commission from Employee

----5
select SSN, (Fname + Lname) as FullName from Employee where Salary > 1000

----6
select SSN, (Fname + Lname) as FullName from Employee where Salary*12 > 10000

----7
select (Fname + Lname) as FullName , Salary from Employee where Sex = 'F'


----8
select Dnum, Dname from Departments where MGRSSN =  968574

----9
select Pnumber, Pname, Plocation from Project where Dnum = 10


