--
-- ========================================================================================================================================================================
--  Configure scope Memebers
-- ========================================================================================================================================================================
--
delete orders;
delete orders_tracking;
delete order_details;
delete order_details_tracking;
delete scope_info;
delete scope_table_map;
insert into scope_info(scope_name) values ('sales');
insert into scope_table_map(scope_name, table_name) values ('sales', 'orders');
insert into scope_table_map(scope_name, table_name) values ('sales', 'order_details');

--
-- ========================================================================================================================================================================
--  Insert Sample Data In Tables
-- ========================================================================================================================================================================
--
--ALTER TRIGGER orders_insert_trigger COMPILE;

insert into orders (order_id, order_date) values(1, SYSDATE);
insert into orders (order_id, order_date) values(4, SYSDATE);

insert into order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'DVD', 5);
insert into order_details (order_id, order_details_id, product, quantity) values(1, 4 , 'CD', 10);
insert into order_details (order_id, order_details_id, product, quantity) values(4, 3 , 'Floppy Disk', 15);

--
-- ========================================================================================================================================================================
--  Bulk Insert Data In Tables
-- ========================================================================================================================================================================
--
/*declare 
 p_index int := 0;
begin
while (p_index < 1000) LOOP
  BEGIN
	insert into orders(order_id, order_Date) values (p_index, SYSDATE);
        EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;
  END;
  BEGIN
	insert into order_details(order_details_id,order_id, product,quantity) values (p_index+1000,p_index, 'aaaa', 100);
       EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;
  END;
	p_index := p_index + 1;
END LOOP;
end;
/

--
-- ========================================================================================================================================================================
--  Cleanup content and metadata
-- ========================================================================================================================================================================
--

delete orders;
delete orders_tracking;
delete order_details;
delete order_details_tracking;
--
-- ========================================================================================================================================================================
--  DML - Test Code
-- ========================================================================================================================================================================
--

insert into orders (order_id, order_date) values(1, SYSDATE);
insert into orders (order_id, order_date) values(4, SYSDATE);

update orders set order_date = SYSDATE where order_id = 4;

delete orders where order_id = 3;

insert into order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'DVD', 5);
--insert into order_details (order_id, order_details_id, product, quantity) values(1, 1 , 'CD', 10);
insert into order_details (order_id, order_details_id, product, quantity) values(4, 4 , 'Floppy Disk', 15);

select * from orders;

select * from orders_tracking;
select * from order_details;
select * from order_details_tracking;
select * from scope_info;*/

