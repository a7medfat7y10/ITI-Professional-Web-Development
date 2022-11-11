--part 1

Use ITI

--1
select count(St_Age) from Student

--2
select distinct Ins_Name from Instructor 

--3
select Student.St_Id as [Student Id], isnull((Student.St_Fname + ' ' + Student.St_Lname), 'Unknown Name') as Fullname, 
isnull (Department.Dept_Name, 'no department') as DepartmentName from Student 
left join Department ON Department.Dept_Id = Student.Dept_Id

--4 
Select Instructor.Ins_Name, Department.Dept_Name from Department right outer join Instructor ON Instructor.Dept_Id = Department.Dept_Id

--5
select (Student.St_Fname + ' ' + Student.St_Lname) as Fullname, Course.Crs_Name as courseName from Student 
inner join Stud_Course ON Stud_Course.St_Id = Student.St_Id and Stud_Course.Grade IS NOT NULL
inner join Course ON Stud_Course.Crs_Id = Course.Crs_Id 

--6 
select count(Course.Crs_Id), Topic.Top_Name from Course inner join Topic ON Course.Top_Id = Topic.Top_Id group by Topic.Top_Name

--7 
select min(Salary) as min_salaray, max(Salary) as max_salary from Instructor

--8
select Instructor.Ins_Name from Instructor where Salary <( select isnull(avg(Salary), '0') from Instructor)

--9
select Department.Dept_Name from Department inner join Instructor ON Instructor.Dept_Id = Department.Dept_Id 
and Instructor.Salary = (select min(Salary) from Instructor)

--10
select	max(Salary) as Maximum ,
		(Select max(Salary) from Instructor where Salary not in (Select max(Salary) from Instructor)) as Second_Max
from Instructor 

--11 Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function”
Select Instructor.Ins_Name, coalesce(convert(varchar(50), Instructor.Salary), 'instructor bonus') from Instructor 

--12
Select isnull(avg(Salary), '0') as Average  from Instructor

--13
Select St.St_Fname ,Sup.* from Student St inner join Student Sup ON Sup.St_Id = St.St_super 

--14select the highest two salaries in Each Department for instructors who have salaries.
Select * From
	(Select Instructor.Salary, Instructor.Dept_Id, ROW_NUMBER() over (Partition by Instructor.Dept_Id order by Instructor.Salary) 
	as Row_Num from Instructor) as Newtable 
where Row_Num <= 2 

--15select a random  student from each department.  “using one of Ranking Functions”
Select * From 
	(Select Student.*, Row_Number() over (Partition by Student.Dept_Id order by newid()) 
	as Row_Num from Student ) as Newtable 
where Row_Num = 1




