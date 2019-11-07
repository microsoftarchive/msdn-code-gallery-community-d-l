SELECT A.*
FROM Customers A
INNER JOIN
 (
   SELECT CompanyName,ContactName,ContactTitle,Address,City,PostalCode
   FROM Customers
   GROUP BY CompanyName,ContactName,ContactTitle,Address,City,PostalCode
   HAVING COUNT(*)>1
 ) B
ON
A.CompanyName=B.CompanyName AND
A.ContactName=B.ContactName AND
A.ContactTitle=B.ContactTitle AND
A.Address=B.Address AND
A.City=B.City AND
A.PostalCode = B.PostalCode
