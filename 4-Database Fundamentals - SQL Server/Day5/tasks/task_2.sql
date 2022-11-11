--part 2

Use AdventureWorks2012

--1
Select SalesOrderId, ShipDate from Sales.SalesOrderHeader where ShipDate between '7/28/2002' and '7/29/2014' 

--2
Select P.ProductID, P.Name  from Production.Product P where P.StandardCost < 110.00

--3
Select P.ProductID, P.Name  from Production.Product P where P.Weight IS NULL


--4
Select P.ProductID, P.Name  from Production.Product P where P.Color in ('Silver','Black', 'Red')

--5
Select P.ProductID, P.Name  from Production.Product P where P.Name Like 'B%'

--6
UPDATE Production.ProductDescription SET Description = 'Chromoly steel_High of defects' WHERE ProductDescriptionID = 3

Select D.Description  from Production.ProductDescription D where D.Description Like'%[_]%'


--7
Select sum(S.TotalDue) from Sales.SalesOrderHeader S group by S.OrderDate having S.OrderDate between '7/1/2001' and '7/31/2014'

--8
Select Distinct HireDate from HumanResources.Employee

--9	 Calculate the average of the unique ListPrices in the Product table
Select avg (ListPrice) from (Select Distinct P.ListPrice from Production.Product P) as average


--10
Select concat('The ', P.Name, ' is only ', P.ListPrice)  from Production.Product P where P.ListPrice between 100 and 120 order by P.ListPrice

--11
--a)
Select S.rowguid, S.Name, S.SalesPersonID, S.Demographics into Sales.[store_Archive] from Sales.Store S 

Select * from Sales.store_Archive

--b)
Select S.rowguid, S.Name, S.SalesPersonID, S.Demographics into Sales.[store_Archive2] from Sales.Store S where 1 = 2

Select * from Sales.store_Archive2

--12.	Using union statement, retrieve the today’s date in different styles using convert or format funtion.
select Format(GETDATE(), 'd', 'en-US')
Union
Select Convert(nchar(20), GETDATE())
Union
Select Concat(year(GETDATE()) , '-' ,MONTH(GETDATE()) , '-' , Day(GETDATE()))
