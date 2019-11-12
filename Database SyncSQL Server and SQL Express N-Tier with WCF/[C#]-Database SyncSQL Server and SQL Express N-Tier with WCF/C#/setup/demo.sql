

--
-- ========================================================================================================================================================================
--  Insert Sample Data In Tables
-- ========================================================================================================================================================================
--
insert into peer1..orders (order_id, order_date) values(1, GetDate())
insert into peer1..orders (order_id, order_date) values(4, GetDate())

insert into peer1..order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'DVD', 5)
insert into peer1..order_details (order_id, order_details_id, product, quantity) values(1, 4 , 'CD', 10)
insert into peer1..order_details (order_id, order_details_id, product, quantity) values(4, 3 , 'Floppy Disk', 15)

--
-- ========================================================================================================================================================================
--  Bulk Insert Data In Tables
-- ========================================================================================================================================================================
--
declare @index int
set @index = 0;
while (@index < 1000)
begin
	insert into orders(order_id, order_Date) values (@index, getdate())
	insert into order_details(order_details_id,order_id, product,quantity) values (@index+1000,@index, replicate('a',50), 100)
	set @index = @index + 1
end
go


--
-- ========================================================================================================================================================================
--  DML - Test Code
-- ========================================================================================================================================================================
--

insert into peer1..orders (order_id, order_date) values(1, GetDate())
insert into peer1..orders (order_id, order_date) values(4, GetDate())

update peer1..orders set order_date = GetDate() where order_id = 4

delete peer1..orders where order_id = 3

insert into peer1..order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'DVD', 5)
insert into peer1..order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'CD', 10)
insert into peer1..order_details (order_id, order_details_id, product, quantity) values(4, 4 , 'Floppy Disk', 15)

select * from peer1..orders
select * from peer2..orders
select * from peer3..orders

select * from peer1..orders_tracking
select * from peer1..order_details
select * from peer1..order_details_tracking
select * from peer1 ..scope_info


