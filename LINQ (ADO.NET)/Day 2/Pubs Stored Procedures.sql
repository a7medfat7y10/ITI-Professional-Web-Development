 use pubs
 ---------------
create proc UpdateTitleNameById @name varchar(80) ,@id varchar(6)
as
update titles
set title =@name where title_id=@id
----------------------------------------------------
create proc UpdateTitleById
@TitleID nvarchar(6),
@TitleName nvarchar(40),
@Type char(12),
@PubID char(4),
@Price money,
@Advance money,
@Royalty int,
@ytd_sales int, 
@notes varchar(200),
@pubdate datetime
as 
UPDATE titles
SET     title = @TitleName, type = @Type,
pub_id = @PubID, price = @Price, advance = @Advance, royalty = @Royalty,ytd_sales= @ytd_sales,notes = @notes, pubdate =@pubdate
WHERE  (title_id = @TitleID)
---------------------------------------------------------------
create proc InsertTitle
@TitleID nvarchar(6),
@TitleName nvarchar(40),
@Type char(12),
@PubID char(4),
@Price money,
@Advance money,
@Royalty int,
@ytd_sales int, 
@notes varchar(200),
@pubdate datetime 
as
 Insert into titles values(
 @TitleID 
 ,@TitleName 
 ,@Type 
 ,@PubID  
 ,@Price  
 ,@Advance 
 ,@Royalty 
 ,@ytd_sales 
 ,@notes  
 ,@pubdate)
 ------------------------------------------------
 create proc DeleteTitle @TitleID varchar(6) 
as
 delete from  titles 
 WHERE  (title_id = @TitleID)

 ----------------------------------------
 create proc SelectPublisherNAME 
 as
 select pub_name,pub_id
 from publishers

