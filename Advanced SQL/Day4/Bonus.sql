--Bonus :

--1.	Transform all functions in lab2 to be stored procedures

Use ITI
-------1.	Create a scalar function that takes date and returns Month name of that date.
create proc getmonth2 @today_date date,@month varchar(50) output
as
		SELECT @month = format (@today_date, 'MMMM') 	
	
declare @x varchar(50)
execute getmonth2 '10/10/2010' ,@x output
select @x



-------2.	 Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
alter proc getbetween2 @start int, @end int 

as
	begin
	declare @t table (num int)
		declare @n1 int
			set @n1 = @start

		while(@n1 <= @end)
		begin
			insert into @t values (@n1) 
			set @n1+=1
		end

		select * from @t
	end
	--calling
	getbetween2 3,8




------3.	 Create inline function that takes Student No and returns Department Name with Student full name.
create proc getStudent2 @std_no int
as
		 select Department.Dept_Name, concat(Student.St_Fname , ' ' , Student.St_Lname) as Fullname
		 from Student inner join Department on Department.Dept_Id = Student.Dept_Id and Student.St_Id = @std_no

--calling
getStudent2 12




--------4.	Create a scalar function that takes Student ID and returns a message to user 
----a.	If first name and Last name are null then display 'First name & last name are null'
----b.	If First name is null then display 'first name is null'
----c.	If Last name is null then display 'last name is null'
----d.	Else display 'First name & last name are not null'

alter proc getsname2 @id int
as
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

			select @name
	end

	--calling
	getsname2 16




---------5.	Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
create proc getManagerinfo2 @mng_id int
as
	select d.Dept_Manager, d.Dept_Name, d.Manager_hiredate from Department d

--calling
getManagerinfo2 10102




--------6.	Create multi-statements table-valued function that takes a string
----If string='first name' returns student first name
----If string='last name' returns student last name 
----If string='full name' returns Full Name from student table 
----Note: Use “ISNULL” function
use ITI
alter proc getName2 @string varchar(30)

as
	begin
	declare  @t table (student varchar(30))
		if (@string ='first name')
			insert into @t
			select isnull(St_Fname,'none') from Student
		else if (@string ='last name')
			insert into @t
			select isnull(St_Lname,'none') from Student
		else if (@string ='full name')
			insert into @t
			select concat(St_Fname,' ',St_Lname) from Student

		select * from @t
	end

getName2 'first name'


-----------------------------------------------------------------------------------------------------



--2.	Create a trigger that prevents users from altering any table in Company DB.
create trigger preventCreate
on database
for CREATE_TABLE
as
	Begin
		select 'Create not allowed'
		rollback transaction
	end

create trigger preventAlter
on database
for ALTER_TABLE
as
		
	Begin
		select 'Alter not allowed'
		rollback transaction
	end

create trigger preventDrop
on database
for DROP_TABLE
as
	Begin
		rollback transaction
		select 'Drop not allowed'
		rollback transaction
	end

