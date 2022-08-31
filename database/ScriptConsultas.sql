--Obtener la lista de precios de todos los productos

SELECT Name, Price, Stock FROM Products 
--------------------------------------------------------------------

--Obtener la lista de productos cuya existencia en el inventario haya llegado al m�nimo permitido (5 unidades)

SELECT * FROM Products WHERE Stock <= 5

--------------------------------------------------------------------

--Obtener una lista de clientes no mayores de 35 a�os que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000

SELECT c.FirstName, c.LastName, c.DateOfBirth, DATEDIFF(YEAR, DateOfBirth ,GETDATE()) as edad
FROM Customers as c
INNER JOIN Invoices as i on i.CustomerId = c.Id
WHERE DATEDIFF(YEAR, DateOfBirth ,GETDATE()) <= 35 and i.Date BETWEEN '2000-02-01 00:00:00' AND '2000-05-25 23:59:59'

--------------------------------------------------------------------

--Obtener el valor total vendido por cada producto en el a�o 2000

SELECT p.Name, SUM(id.SubTotal) as TotalVendido
FROM Invoices as i
INNER JOIN InvoiceDetails as id on i.Id = id.InvoiceId
INNER JOIN Products as p on p.Id = id.ProductId
WHERE i.Date BETWEEN '2000-01-01 00:00:00' AND '2000-12-31 23:59:59'
GROUP BY id.ProductId, p.Name 


--------------------------------------------------------------------

--Obtener la �ltima fecha de compra de un cliente y seg�n su frecuencia de compra estimar en qu� fecha podr�a volver a comprar.