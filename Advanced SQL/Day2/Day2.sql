Use ITI
--1.	Create a scalar function that takes date and returns Month name of that date.
create function getmonth(@today_date date)
returns nvarchar(20)
begin
declare @month nvarchar(20)
		set @month = format (@today_date, 'MMMM')
return @month 	
end 
--calling
select dbo.getmonth('2016.1.1') 

--2.	 Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
create function getbetween(@start int, @end int )
returns @t table
			(
			 id int
			)
as
	begin
		declare @n1 int
			set @n1 = @start

		while(@n1 <= @end)
		begin
			insert into @t values (@n1) 
			set @n1+=1
		end
		return 	
	end

	select * from getbetween(3,8)

--3.	 Create inline function that takes Student No and returns Department Name with Student full name.
create function getStudent(@std_no int)
returns table
as
	return 
		(
		 select Department.Dept_Name, concat(Student.St_Fname , ' ' , Student.St_Lname) as Fullname
		 from Student inner join Department on Department.Dept_Id = Student.Dept_Id and Student.St_Id = @std_no
		)

--calling
select * from getStudent(12)

--4.	Create a scalar function that takes Student ID and returns a message to user 
----a.	If first name and Last name are null then display 'First name & last name are null'
----b.	If First name is null then display 'first name is null'
----c.	If Last name is null then display 'last name is null'
----d.	Else display 'First name & last name are not null'

create function getsname(@id int) 
returns varchar(30)
	begin
		declare @name varchar(30)
		
		declare @lname varchar(30)
		    select @lname=St_Lname from Student
			where st_id=@id
		declare @fname varchar(30)
		    select @fname=St_Fname from Student
			where st_id=@id

		if((@fname is null) and (@lname is null))
			set @name = 'First name & last name are null'
		else if(@fname is null)
			set @name = 'First Name is Null'
		else if(@lname is null)
			set @name = 'last Name is Null'
		else 
			set @name = 'First name & last name are not null'
		return @name
	end

	select dbo.getsname(16)


--5.	Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
create function getManagerinfo(@mng_id int)
returns table
as
	return 
		(
			select i.Ins_Id, d.Dept_Name, d.Manager_hiredate 
			from Instructor i, Department d 
			where d.Dept_Id = i.Dept_Id
		)

--calling
select * from getManagerinfo(10102)


--6.	Create multi-statements table-valued function that takes a string
----If string='first name' returns student first name
----If string='last name' returns student last name 
----If string='full name' returns Full Name from student table 
----Note: Use “ISNULL” function
use ITI


create function getName(@string varchar(30))
returns @t table
			(
			 student varchar(30)
			)
as
	begin
		if (@string ='first name')
			insert into @t
			select isnull(St_Fname,'none') from Student
		else if (@string ='last name')
			insert into @t
			select isnull(St_Lname,'none') from Student
		else if (@string ='full name')
			insert into @t
			select concat(St_Fname,' ',St_Lname) from Student
		return
	end

	select * from getName('first name')

--7.	Write a query that returns the Student No and Student first name without the last char
Select Student.St_Id, substring(Student.St_Fname, 0, len(St_Fname)) from Student


--8.	Wirte query to delete all grades for the students Located in SD Department 
--Delete  Stud_Course from Stud_Course, Department, Student where Department.Dept_Id =Student.Dept_Id and Stud_Course.St_Id =  Student.St_Id
--and  Department.Dept_Name = 'SD' 

Update  Stud_Course set Grade = NULL from Stud_Course, Department, Student where Department.Dept_Id =Student.Dept_Id and Stud_Course.St_Id =  Student.St_Id
and  Department.Dept_Name = 'SD' 


--Bonus:
--2.	Create a batch that inserts 3000 rows in the student table(ITI database). 
---The values of the st_id column should be unique and between 3000 and 6000. All values of the columns st_fname, st_lname, should be set to 'Jane', ' Smith' respectively.
declare @stid int = 3000 
while (@stid<6000)
begin 
	insert into Student ( St_Id,St_Fname,St_Lname)
	values (@stid , 'Jane','Smith')
	set @stid+=1
end 