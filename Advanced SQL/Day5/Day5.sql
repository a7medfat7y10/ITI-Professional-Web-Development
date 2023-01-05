use SD

--1.	Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 and increases it by 20% if Salary >=3000. Use company DB

declare c1 cursor
for select Emp.Salary from Emp
for update

declare @salary int
open c1
fetch c1 into @salary
while @@FETCH_STATUS=0
	begin
		if @salary>=3000
			update Emp   
				set salary=@salary*1.20
			where current of c1
		else if @salary<3000
			update Emp
				set salary=@salary*1.10
			where current of c1
		fetch c1 into @salary
	end
close c1
deallocate c1

--2.	Display Department name with its manager name using cursor. Use ITI DB
use ITI
declare c2 cursor
for select d.Dept_Name , i.Ins_Name from Department d, Instructor i where d.Dept_Manager = i.Ins_Id
for read only 

declare @dept varchar(50), @mng varchar(50)
open c2
fetch c2 into @dept, @mng
while @@FETCH_STATUS=0
	begin
		select @dept, @mng
		fetch c2 into @dept, @mng
	end
close c2
deallocate c2

--3.	Try to display all students first name in one cell separated by comma. Using Cursor 
declare c3 cursor
for select Student.St_Fname from Student
for read only 

declare @st_name varchar(30), @names varchar(200)
open c3
fetch c3 into @st_name
while @@FETCH_STATUS=0
	begin
		select @names = CONCAT(@names, ',' , @st_name)
		fetch c3 into @st_name
	end
	select @names
close c3
deallocate c3

--4.	Create full, differential Backup for SD DB.

--5.	Use import export wizard to display students data (ITI DB) in excel sheet

--6.	Try to generate script from DB ITI that describes all tables and views in this DB

--7.	Create a sequence object that allow values from 1 to 10 without cycling in a specific column and test it.

create SEQUENCE seq1 START WITH 1 INCREMENT BY 1 MINVALUE 1 MAXVALUE 10 NO CYCLE

create table test (id int, fname nvarchar(50))

INSERT into TestVALUES (NEXT VALUE FOR seq1, 'ahmed')
