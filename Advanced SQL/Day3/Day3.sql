Use ITI

--1.	Create a view that displays student full name, course name if the student has a grade more than 50. 
create view VSname(Fullname,Coursename)
as
	select Student.St_Fname + ' ' + Student.St_Lname as Fullname, Course.Crs_Name 
	from Student, Course, Stud_Course 
	where Stud_Course.St_Id = Student.St_Id and Course.Crs_Id = Stud_Course.Crs_Id and Stud_Course.Grade > 50

select * from VSname

--2.	 Create an Encrypted view that displays manager names and the topics they teach. 
create view vManager (mname, topic)
with encryption
as
select Instructor.Ins_Name , Topic.Top_Name
from Instructor inner join Department on Instructor.Ins_Id = Department.Dept_Manager
inner join Ins_Course on Ins_Course.Ins_Id = Instructor.Ins_Id
inner join Course on Course.Crs_Id = Ins_Course.Crs_Id 
inner join Topic on Topic.Top_Id=Course.Top_Id

select * from vManager

Sp_helptext 'vjoin'

--3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
create view instructor_view
as
select Instructor.Ins_Name ,Department.Dept_Name
from Department inner join Instructor on Instructor.Dept_Id =Department.Dept_Id
where Department.Dept_Name = 'SD' or Department.Dept_Name = 'Java'

select * from instructor_view

--4.	 Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’ Where st_address=’alex’;

create view V1
as
select * from Student where St_Address in('Alex','Cairo') with check option

select * from V1

update V1 set St_Address='tanta' --error

--5.	Create a view that will display the project name and the number of employees work on it. “Use SD database”
use SD
create view project_View
as
select P.ProjectName,count(E.EmpNo) as num_of_employees from Company.Project P inner join Works_on W on P.ProjectNo=W.ProjectNo
inner join HR.Employee E on E.EmpNo=W.EmpNo group by P.ProjectName

select * from project_View

--6.	Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
create clustered index  HI on Department(Manager_hiredate) --error


--7.	Create index that allow u to enter unique ages in student table. What will happen? 
create unique index AI on Student(St_Age)
--ERROR: The CREATE UNIQUE INDEX statement terminated because a 
--duplicate key was found for the object name 'dbo.Student' 
--and the index name 'age_index'. The duplicate key value is (28).


--8.	Using Merge statement between the following two tables [User ID, Transaction Amount]
create table Lastt
(
 Lid int,
 Xval int
)

create table Dailyt
(
 did int,
 Yval int
)
insert into Lastt values(1,1000)
insert into Lastt values(2,2000)
insert into Lastt values(3,3000)

insert into Dailyt values(1,4000)
insert into Dailyt values(2,2000)
insert into Dailyt values(3,10000)


merge into Lastt as L using Dailyt as D  on D.did=L.Lid
when matched  then update set L.lid=D.did
when not matched then insert values(did,yval);

select * from Lastt
 
use SD
--1)	Create view named   “v_clerk” that will display employee#,project#, the date of hiring of all the jobs of the type 'Clerk'.

create view v_clerk 
as
select E.EmpNo, P.ProjectNo, W.Enter_Date from Emp E, Company.Project P, Works_on W 
where E.EmpNo = W.EmpNo and W.ProjectNo = P.ProjectNo and W.Job = 'Clerk'

select * from v_clerk

--2)	 Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget
as 
select ProjectName,ProjectNo from Company.Project

select * from  v_without_budget

--3)	Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count
as
select P.ProjectName,count(W.Job) as num_of_jobs from Company.Project P,Works_on W where P.ProjectNo=W.ProjectNo group by P.ProjectName 

select * from v_count


--4)	 Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’ use the previously created view  “v_clerk”
create view v_project_p2
as
select v.EmpNo, v.ProjectNo from v_clerk v,Company.Project p where v.ProjectNo=p.ProjectNo and v.ProjectNo='p2' 

select * from v_project_p2


--5)	modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 
alter view v_without_budget
as 
select * from Company.Project where ProjectNo in ('p1','p2')

select * from v_without_budget


--6)	Delete the views  “v_ clerk” and “v_count”
drop view v_clerk 
drop view v_count

--7)	Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
create view displayEmp
as
select e.EmpNo,e.EmpLname from Emp e,Company.Department d where e.DeptNo=d.DeptNo and d.DeptNo='d2'

select * from displayEmp

--8)	Display the employee  lastname that contains letter “J” Use the previous view created in Q#7
select EmpLname from displayEmp where EmpLname like '%j%'


--9)	Create view named “v_dept” that will display the department# and department name.
create view v_dept
as
select DeptNo, DeptName from Company.Department 

select * from v_dept

--10)	using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’
insert into v_dept values('d4', 'Development')


--11)	Create view name “v_2006_check” that will display employee#, the project # where he works and the date of joining the project 
--which must be from the first of January and the last of December 2006.
create view v_2006_check
as
select e.EmpNo, p.ProjectNo, d.Location, w.Enter_Date from Emp e,Company.Project p, Works_on w,Company.Department d 
where d.DeptNo=e.DeptNo and e.EmpNo=w.EmpNo and w.ProjectNo = p.ProjectNo and Enter_Date between '2006.1.1'and'2006.12.31'

select * from v_2006_check

