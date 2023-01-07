Use ITI

--1.	Create a stored procedure without parameters to show the number of students per department name.[use ITI DB] 
create Procedure num_of_std_by_dept
as
select count(Student.St_Id) as number_of_students, Department.Dept_Name from Student, Department 
where Department.Dept_Id = Student.Dept_Id group by Department.Dept_Name

--calling
num_of_std_by_dept 
exec num_of_std_by_dept 
execute num_of_std_by_dept 

Use SD
--2.	Create a stored procedure that will check for the # of employees in the project p1 if they are more than 3 print message to the user 
--“'The number of employees in the project p1 is 3 or more'” if they are less display a message to the user 
--“'The following employees work for the project p1'” in addition to the first name and last name of each one. [Company DB] 

create Procedure num_of_emps
as
	
	if (select COUNT(Emp.EmpNo) from Emp, Company.Project p, Works_on 
	where Works_on.EmpNo = Emp.EmpNo and Works_on.ProjectNo = p.ProjectNo and p.ProjectNo='p1') >3
		select 'The number of employees in the project p1 is 3 or more'
	else 
		select 'The following employees work for the project p1 ' + Emp.EmpFname + ' ' + Emp.EmpLname from Emp, Company.Project p, Works_on 
		where Works_on.EmpNo = Emp.EmpNo and Works_on.ProjectNo = p.ProjectNo and p.ProjectNo='p1'

	--calling
	num_of_emps





--3.	Create a stored procedure that will be used in case there is an old employee has left the project and a new one become instead of him. 
--The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. [Company DB]
alter Procedure emp_update @oldEmp# int, @newEmp# int , @projectnum  varchar(20)
as
		if not exists (select Emp.EmpNo from Emp where EmpNo = @newEmp#)
			select 'this cannot be updated'
		else if  exists (select EmpNo  from Works_on where @newEmp# = EmpNo and ProjectNo = @projectnum)
			select 'this cannot be updated'
		else
			update Works_on set EmpNo = @newEmp# where ProjectNo = @projectnum and Empno = @oldEmp#

--calling
emp_update 2,4,'p1'


--4.	add column budget in project table and insert any draft values in it then 
--then Create an Audit table with the following structure 
--ProjectNo 	UserName 	ModifiedDate 	Budget_Old 	Budget_New 
--p2 	Dbo 	2008-01-31	95000 	200000 

--This table will be used to audit the update trials on the Budget column (Project table, Company DB)
--Example:
--If a user updated the budget column then the project number, user name that made that update, the date of the modification and the value of the old and the new budget will be inserted into the Audit table
--Note: This process will take place only if the user updated the budget column
create table History(
	projectNo varchar(50),
	UserName varchar(100),
	ModifidDate date,
	Budget_Old int,
	Budget_New int,
)

create trigger t1
on Company.Project
instead of update
as
	if update(Budget)
		begin
			declare @old int, @new int ,@pro varchar(50)
			select @old=Budget from deleted
			select @new=Budget from inserted
			select @pro = ProjectNo from inserted
			insert into History
			values(@pro, suser_name(),getdate(),@old,@new)
		end

update Company.Project set Budget= 20555000 where ProjectNo = 'p2'






--5.	Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in that table”

USE ITI
create trigger t2
on Department
instead of insert
as
	select 'you can’t insert a new record in that table'

insert into Department values(80 ,'xml' , 'pd'  , 'smart' ,1, '2000.1.1')




--6.	 Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
USE  SD

create trigger HR.t3
on HR.Employee
after insert
as
	if format(getdate(),'MMMM')='March'
	begin
			select 'not allowed'
	end
	else 
			insert into HR.Employee select * from inserted


insert into HR.Employee values (1018, 'ahmeds' , 'alis' , 'd3',3254)


--7.	Create a trigger on student table after insert to add Row in Student Audit table 
--(Server User Name , Date, Note) where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”
--Server User Name		Date Note 
		
USE ITI
create table StudentAudit(
	serverUserName varchar(50),
	myDate date,
	Note varchar (50)
)

alter trigger t4
on Student
after insert
as
	insert into StudentAudit (serverUserName , myDate , Note)
	select SUSER_SNAME() , GETDATE() , concat(SUSER_NAME() ,' Inserted id ' , St_Id , ' in Sutdent ') 
	from Student where St_Id in (select st_id from inserted)
	
	--test
	insert into Student values(40,'ahmed', 'fathy', 'cairo', 24, 20,9)

--8.	 Create a trigger on student table instead of delete 
--to add Row in Student Audit table (Server User Name, Date, Note) where note will be
--“ try to delete Row with Key=[Key Value]”
alter trigger t5
on Student
instead of delete
as

	insert into StudentAudit  (serverUserName , myDate , Note)
	select SUSER_SNAME() , GETDATE() , concat(SUSER_NAME(), ' try to delete ' , St_Id, 'in Sudent')
	from Student where St_Id in (select st_id from deleted)

	--test
	delete from Student where Student.St_Id= 37

	
use AdventureWorks2012
--9.	Display all the data from the Employee table (HumanResources Schema) 
--As an XML document “Use XML Raw”. “Use Adventure works DB” 
--A)	Elements
select * from HumanResources.Employee for xml raw('Employee'),elements

--B)	Attributes
select * from HumanResources.Employee for xml raw('Employee')


use ITI
--10.	Display Each Department Name with its instructors. “Use ITI DB”
--A)	Use XML Auto
select Dept_name, Ins_Name from Instructor , Department
where Instructor.Dept_Id = Department.Dept_Id for xml auto

--B)	Use XML Path
select Dept_name, Ins_Name from Instructor , Department
where Instructor.Dept_Id = Department.Dept_Id for xml path

use SD
--11.	Use the following variable to create a new table “customers” inside the company DB.
 --Use OpenXML
declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
			</customers>'

declare @hdocs int

Exec sp_xml_preparedocument @hdocs output, @docs

SELECT * 
FROM OPENXML (@hdocs, '//customer')  
WITH (FirstName varchar(50) '@FirstName',
	  Zipcode int '@Zipcode', 
	  customer_order varchar(50) 'order',
	  order_id int 'order/@ID'
	  )

exec sp_xml_removedocument @hdocs



