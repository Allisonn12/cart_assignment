USE carter;

-- Import the tables
CREATE TABLE [dbo].[SQL_Test_Dealers](
[DealerID] [int] IDENTITY(1,1) NOT NULL,
[Dealership_Name] [nvarchar](255) NULL
)
GO
CREATE TABLE [dbo].[SQL_Test_Dealer_Sales](
[DealerID] [int] NULL,
[DateOfSale] [datetime] NULL,
[SaleAmount] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
INSERT INTO SQL_Test_Dealers (Dealership_Name) VALUES ('Joburg')
INSERT INTO SQL_Test_Dealers (Dealership_Name) VALUES ('Durban')
INSERT INTO SQL_Test_Dealers (Dealership_Name) VALUES ('Cape Town')
INSERT INTO SQL_Test_Dealers (Dealership_Name) VALUES ('Polokwane')
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (1, '2022-10-01', 160000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (1, '2022-10-12', 150000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (2, '2022-10-01', 190000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (3, '2022-10-01', 80000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (3, '2022-10-11', 100000)

INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (3, '2022-10-24', 132000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (4, '2022-10-01', 210000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (1, '2022-11-05', 110000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (2, '2022-11-07', 130000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (3, '2022-11-10', 180000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (1, '2022-12-09', 50000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (1, '2022-12-15', 99000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (2, '2022-12-29', 126000)
INSERT INTO SQL_Test_Dealer_Sales (DealerID, DateOfSale, SaleAmount) VALUES (4, '2022-12-22', 120000)


-- Create procedure
CREATE PROCEDURE getDealership @DealerID nvarchar(255) AS 
SELECT test_deler.Dealership_Name, dealer_sales.SaleAmount
FROM SQL_Test_Dealers test_deler 
INNER JOIN SQL_Test_Dealer_Sales dealer_sales ON test_deler.DealerID = dealer_sales.DealerID
WHERE test_deler.DealerID = @DealerID;

-- Exec procedure
EXEC getDealership @DealerID = 2



-- Get total number of sales per dealership
SELECT MAX(sales.DateOfSale) AS [Date of sale], dealer.Dealership_Name AS [DEALER NAME], COUNT(*) AS [SALES AMOUNT]
FROM SQL_Test_Dealer_Sales sales
INNER JOIN SQL_Test_Dealers dealer on sales.DealerID = dealer.DealerID
GROUP BY dealer.Dealership_Name
