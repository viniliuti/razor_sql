-- Setting up temporary tables
IF OBJECT_ID('tempdb..#customer') IS NOT NULL DROP TABLE #customer;
IF OBJECT_ID('tempdb..#orders') IS NOT NULL DROP TABLE #orders;
IF OBJECT_ID('tempdb..#orders_detail') IS NOT NULL DROP TABLE #orders_detail;

CREATE TABLE #customer
(
	FirstName VARCHAR(50), 
	LastName VARCHAR(100),
	Age INT,
	Occupation VARCHAR(50),
	MartialStatus VARCHAR(50), -- married, single, widowed, divorced, separated
	PersonID INT IDENTITY PRIMARY KEY
);

CREATE TABLE #orders
(
	OrderID INT IDENTITY PRIMARY KEY,
	PersonID INT,
	DateCreated DATETIME,
	MethodofPurchase VARCHAR(50)	
);

CREATE TABLE #orders_detail
(
	OrderID INT,
	OrderDetailID INT IDENTITY PRIMARY KEY,
	ProductNumber INT,
	ProductID INT,
	ProductOrigin VARCHAR(100)
);


-- Mock data
INSERT INTO #customer (FirstName, LastName, Age, Occupation, MartialStatus)
values 
	('John', 'Doe', 50, 'Analyst', 'Divorced'),
	('Jane', 'Doe', 26, 'N/A', 'Single'),
	('João', 'Maria', 47, 'Teacher', 'Married');

INSERT INTO #orders (PersonID, DateCreated, MethodofPurchase)
values 
	(1, Convert(Datetime, '2022-01-05 15:43:22', 120), 'Debit'),
	(1, Convert(Datetime, '2022-01-10 10:00:02', 120), 'Debit'),
	(2, Convert(Datetime, '2022-01-20 23:44:29', 120), 'Credit'),
	(3, Convert(Datetime, '2022-01-30 06:00:30', 120), 'Credit');

-- To mess with data 
SET IDENTITY_INSERT #orders ON;

INSERT INTO #orders(OrderId, PersonID, DateCreated, MethodofPurchase)
SELECT 99, 3, CONVERT(DATETIME, '2022-12-12 12:12:30', 120), 'Future';

SET IDENTITY_INSERT #orders OFF;

INSERT INTO #orders_detail (OrderID, ProductNumber, ProductID, ProductOrigin)
values 
	(1, 10, 1, 'Brazil'), 
	(2, 99, 105, 'Argentina'), 
	(1, 123, 1112222333, 'Chile'), 
	(2, 123, 1112222333, 'Chile'), 
	(3, 33, 1112222444, 'Peru'),
	(99, 99999, 1112222333, 'Chile'),
	(99, 1, 1112222333, 'US');

/*
	Request:

	Please return a result of the customers who ordered 
	product ID = 1112222333 

	and return
	
	FirstName and LastName as full name, 
	age, 
	orderid, 
	datecreated, 
	MethodOfPurchase as Purchase Method, 
	ProductNumber and 
	ProductOrigin
*/
SELECT 
	c.FirstName + ' ' + c.LastName AS FullName, 
	c.Age, 
	o.OrderID, 
	o.DateCreated, 
	o.MethodofPurchase AS [Purchase Method], 
	od.ProductNumber, 
	od.ProductOrigin
FROM 
	#customer as c
INNER JOIN 
	#orders AS o 
	ON c.PersonID = o.PersonID
INNER JOIN 
	#orders_detail AS od
	ON o.OrderID = od.OrderID
WHERE
	od.ProductID = 1112222333;