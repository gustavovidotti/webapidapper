--CREATE PROCEDURE spGetCustomerOrdersCount
--	@Document CHAR(11)
--AS
SELECT
    c.[Id],
    CONCAT(c.[FirstName],' ',c.[LastName]) AS [Name],
    c.[Document],
    COUNT(o.ID)
FROM [Customer] c
    INNER JOIN [Order] o
    ON o.[CustomerID] = c.[ID]

