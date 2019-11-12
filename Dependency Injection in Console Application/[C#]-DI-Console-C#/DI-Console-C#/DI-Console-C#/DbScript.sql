Create Table Employee
(
EmployeeId bigint identity(1,1) primary key,
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(100)
)