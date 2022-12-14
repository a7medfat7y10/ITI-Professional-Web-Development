USE [ITI]
GO
/****** Object:  User [iti]    Script Date: 12/30/2022 5:53:35 PM ******/
CREATE USER [iti] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ITIStud]    Script Date: 12/30/2022 5:53:35 PM ******/
CREATE USER [ITIStud] FOR LOGIN [ITIStud] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [koko]    Script Date: 12/30/2022 5:53:35 PM ******/
CREATE USER [koko] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [iti]    Script Date: 12/30/2022 5:53:35 PM ******/
CREATE SCHEMA [iti]
GO
/****** Object:  UserDefinedFunction [dbo].[getbetween]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getbetween](@start int, @end int )
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
GO
/****** Object:  UserDefinedFunction [dbo].[getmonth]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getmonth](@today_date date)
returns nvarchar(20)
begin
declare @month nvarchar(20)
		set @month = format (@today_date, 'MMMM')
return @month 	
end 
GO
/****** Object:  UserDefinedFunction [dbo].[getName]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[getName](@string varchar(30))
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
GO
/****** Object:  UserDefinedFunction [dbo].[getsname]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getsname](@id int) 
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
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[St_Id] [int] NOT NULL,
	[St_Fname] [nvarchar](50) NULL,
	[St_Lname] [nchar](10) NULL,
	[St_Address] [nvarchar](100) NULL,
	[St_Age] [int] NULL,
	[Dept_Id] [int] NULL,
	[St_super] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Dept_Id] [int] NOT NULL,
	[Dept_Name] [nvarchar](50) NULL,
	[Dept_Desc] [nvarchar](100) NULL,
	[Dept_Location] [nvarchar](50) NULL,
	[Dept_Manager] [int] NULL,
	[Manager_hiredate] [date] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Dept_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[getStudent]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getStudent](@std_no int)
returns table
as
	return 
		(
		 select Department.Dept_Name, concat(Student.St_Fname , ' ' , Student.St_Lname) as Fullname
		 from Student inner join Department on Department.Dept_Id = Student.Dept_Id and Student.St_Id = @std_no
		)
GO
/****** Object:  Table [dbo].[Course]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Crs_Id] [int] NOT NULL,
	[Crs_Name] [nvarchar](50) NULL,
	[Crs_Duration] [int] NULL,
	[Top_Id] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stud_Course]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stud_Course](
	[Crs_Id] [int] NOT NULL,
	[St_Id] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_Stud_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC,
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VSname]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VSname](Fullname,Coursename)
as
	select Student.St_Fname + ' ' + Student.St_Lname as Fullname, Course.Crs_Name 
	from Student, Course, Stud_Course 
	where Stud_Course.St_Id = Student.St_Id and Course.Crs_Id = Stud_Course.Crs_Id and Stud_Course.Grade > 50
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Top_Id] [int] NOT NULL,
	[Top_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Top_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ins_Course]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ins_Course](
	[Ins_Id] [int] NOT NULL,
	[Crs_Id] [int] NOT NULL,
	[Evaluation] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ins_Course] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC,
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 12/30/2022 5:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[Ins_Id] [int] NOT NULL,
	[Ins_Name] [nvarchar](50) NULL,
	[Ins_Degree] [nvarchar](50) NULL,
	[Salary] [money] NULL,
	[Dept_Id] [int] NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
