--
-- ========================================================================================================================================================================
--  PEER 1 - Stored Procs
-- ========================================================================================================================================================================
--
--
--  ********************************************************************
--     Select Incremental Changes Procs for orders and order_details
--  ********************************************************************
--
create or replace
procedure sp_orders_selectchanges (
    sync_min_timestamp IN number,
    sync_metadata_only IN int,
    sync_scope_local_id IN int,
    sync_changes OUT sys_refcursor)
IS
begin
    open sync_changes for select  t.order_id,
            o.order_date, 
            t.sync_row_is_tombstone,
            t.local_update_peer_timestamp as sync_row_timestamp, 
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_timestamp else t.scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_key else t.scope_update_peer_key end as sync_update_peer_key,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_timestamp else t.scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_key else t.scope_create_peer_key end as sync_create_peer_key
    from orders o right join orders_tracking t on o.order_id = t.order_id
    where t.local_update_peer_timestamp > sync_min_timestamp;
end;
/


create or replace
procedure sp_order_details_selectchanges (
	sync_min_timestamp IN number,
	sync_metadata_only IN int,
	sync_scope_local_id IN int,
  sync_changes OUT sys_refcursor)
IS
begin
    open sync_changes for select  t.order_details_id,
            o.order_id,
			o.product,
			o.quantity,
            t.sync_row_is_tombstone,
            t.local_update_peer_timestamp as sync_row_timestamp, 
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_timestamp else t.scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_key else t.scope_update_peer_key end as sync_update_peer_key,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_timestamp else t.scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_key else t.scope_create_peer_key end as sync_create_peer_key
    from order_details o right join order_details_tracking t on o.order_details_id = t.order_details_id
    where t.local_update_peer_timestamp > sync_min_timestamp;
END;
/

--
--  ***********************************************
--     Insert Procs for orders and order_details
--  ***********************************************
--
create or replace
procedure sp_orders_applyinsert (						
        order_id IN int,
        order_date IN date,
		sync_row_count OUT int)        
IS
BEGIN
	    insert into orders (order_id, order_date) 
	        values (order_id, order_date);
         sync_row_count := sql%rowcount;
         EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;	
END;
/

create or replace
procedure sp_order_details_applyinsert (						
        order_id IN int,
        order_details_id IN int,
        product IN nvarchar2,
        quantity IN int,
		sync_row_count OUT int)        
IS
BEGIN
	    insert into order_details (order_id, order_details_id, product, quantity) 
	        values (order_id, order_details_id, product, quantity);
           sync_row_count := sql%rowcount;
          EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;
END;
/

create or replace
procedure sp_orders_insert_md (
        order_id IN int,
        sync_scope_local_id IN int,
        sync_row_is_tombstone IN int,
        sync_create_peer_key IN int ,
        sync_create_peer_timestamp IN number,                 
        sync_update_peer_key IN int ,
        sync_update_peer_timestamp IN number,                              
        sync_check_concurrency IN int,    
        sync_row_timestamp IN number,  
        sync_row_count OUT int)        
IS
BEGIN
  DECLARE
    p_order_id int := order_id;
  BEGIN
  update orders_tracking set 
    create_scope_local_id = sync_scope_local_id, 
    scope_create_peer_key = sync_create_peer_key,
    scope_create_peer_timestamp = sync_create_peer_timestamp,
    local_create_peer_key = 0,
    local_create_peer_timestamp = sequence_timestamp.nextval,
    update_scope_local_id = sync_scope_local_id,
    scope_update_peer_key = sync_update_peer_key,
    scope_update_peer_timestamp = sync_update_peer_timestamp,
    local_update_peer_key = 0,
    local_update_peer_timestamp = sequence_timestamp.nextval,
    sync_row_is_tombstone = sync_row_is_tombstone 
    where order_id = p_order_id
    and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);    
	sync_row_count := sql%rowcount;
	if (sync_row_count = 0 ) then
		-- inserting metadata for row if it does not already exist
		-- this can happen if a node sees a delete for a row it never had, we insert only metadata
		-- for the row in that case
		insert into orders_tracking (	
		order_id,
		create_scope_local_id, 
		scope_create_peer_key,
		scope_create_peer_timestamp,
		local_create_peer_key,
		local_create_peer_timestamp,
		update_scope_local_id,
		scope_update_peer_key,
		scope_update_peer_timestamp,
		local_update_peer_key,
		local_update_peer_timestamp,
		sync_row_is_tombstone )values (
		p_order_id,
		sync_scope_local_id, 
		sync_create_peer_key,
		sync_create_peer_timestamp,
		0,
		sequence_timestamp.nextval,
		sync_scope_local_id,
		sync_update_peer_key,
		sync_update_peer_timestamp,
		0,
		sequence_timestamp.nextval,
		sync_row_is_tombstone);
		sync_row_count := sql%rowcount;
	end if;
  END;
END;
/

create or replace procedure sp_order_details_insert_md (
        order_details_id IN int,
        sync_scope_local_id IN int,
        sync_row_is_tombstone IN int,
        sync_create_peer_key IN int ,
        sync_create_peer_timestamp IN number,                 
        sync_update_peer_key IN int,
        sync_update_peer_timestamp IN number,                              
        sync_check_concurrency IN int,    
        sync_row_timestamp IN number,  
        sync_row_count OUT int)        
IS
BEGIN
  DECLARE
    p_order_details_id int := order_details_id;
  BEGIN
  
  update order_details_tracking set 
    create_scope_local_id = sync_scope_local_id, 
    scope_create_peer_key = sync_create_peer_key,
    scope_create_peer_timestamp = sync_create_peer_timestamp,
    local_create_peer_key = 0,
    local_create_peer_timestamp = sequence_timestamp.nextval,
    update_scope_local_id = sync_scope_local_id,
    scope_update_peer_key = sync_update_peer_key,
    scope_update_peer_timestamp = sync_update_peer_timestamp,
    local_update_peer_key = 0,
    local_update_peer_timestamp = sequence_timestamp.nextval,
    sync_row_is_tombstone = sync_row_is_tombstone 
    where order_details_id = p_order_details_id
    and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);
    
	sync_row_count := sql%rowcount;
	
	if (sync_row_count = 0 ) then
		-- inserting metadata for row if it does not already exist
		-- this can happen if a node sees a delete for a row it never had, we insert only metadata
		-- for the row in that case
		insert into order_details_tracking (	
		order_details_id,
		create_scope_local_id, 
		scope_create_peer_key,
		scope_create_peer_timestamp,
		local_create_peer_key,
		local_create_peer_timestamp,
		update_scope_local_id,
		scope_update_peer_key,
		scope_update_peer_timestamp,
		local_update_peer_key,
		local_update_peer_timestamp,
		sync_row_is_tombstone )values (
		p_order_details_id,
		sync_scope_local_id, 
		sync_create_peer_key,
		sync_create_peer_timestamp,
		0,
		sequence_timestamp.nextval,
		sync_scope_local_id,
		sync_update_peer_key,
		sync_update_peer_timestamp,
		0,
		sequence_timestamp.nextval,
		sync_row_is_tombstone);
    
		sync_row_count := sql%rowcount;
  end if;
 END;
END;
/


--
--  ***********************************************
--     Update Procs for orders and order_details
--  ***********************************************
--

create or replace
procedure sp_orders_applyupdate (									
        order_id IN int ,
        order_date IN date,
		sync_force_write IN int,
		sync_min_timestamp IN number, 								
		sync_row_count OUT int)        
IS
  BEGIN
    DECLARE
      p_order_id int := order_id;
      p_order_date_ date := order_date;
    BEGIN
      update orders o
      set 
        order_date = order_date   
      where o.order_id in
        (select order_id from orders_tracking t
        where (t.local_update_peer_timestamp <= sync_min_timestamp or sync_force_write = 1)       
        and t.order_id = p_order_id);
      sync_row_count := sql%rowcount;  
    END;
END;                  		
/

create or replace
procedure sp_order_details_applyupdate (									
        order_id IN int,
        order_details_id IN int,
        quantity IN int,
        product IN nvarchar2,
		sync_force_write IN int,
		sync_min_timestamp IN number,
		sync_row_count OUT int)        
IS
  BEGIN
    DECLARE
      p_order_id int := order_id;
      p_order_details_id int := order_details_id;
      p_quantity int := quantity;
      p_product nvarchar2(100) := product;
    BEGIN
      update order_details o
      set 
        o.order_id = p_order_id,
	o.product = p_product,
	o.quantity = p_quantity  
      where o.order_details_id in
        (select order_details_id from order_details_tracking t
        where (t.local_update_peer_timestamp <= sync_min_timestamp or sync_force_write = 1)       
        and t.order_details_id = p_order_details_id);
      sync_row_count := sql%rowcount;                   		
    END;
END;                  		
/

create or replace
procedure sp_orders_update_md (
		order_id IN int,
		sync_scope_local_id IN int,
    sync_row_is_tombstone IN int,
    sync_create_peer_key IN int ,
    sync_create_peer_timestamp IN number,                 
    sync_update_peer_key IN int,
    sync_update_peer_timestamp IN number,                      
    sync_row_timestamp IN number,
    sync_check_concurrency IN int,        
    sync_row_count OUT int)        
IS
BEGIN
  DECLARE 
    p_order_id int := order_id;
    was_tombstone int;
  BEGIN
	select sync_row_is_tombstone into was_tombstone from orders_tracking 
	where order_id = p_order_id;
	
	if (was_tombstone is not null and was_tombstone=1 and sync_row_is_tombstone=0) then
		-- tombstone is getting resurrected, update creation version as well
		update orders_tracking set
			update_scope_local_id = sync_scope_local_id, 
            scope_update_peer_key = sync_update_peer_key,
            scope_update_peer_timestamp = sync_update_peer_timestamp,
            local_update_peer_key = 0,
            local_update_peer_timestamp = sequence_timestamp.nextval,
            create_scope_local_id = sync_scope_local_id, 
            scope_create_peer_key = sync_create_peer_key, 
            scope_create_peer_timestamp =  sync_create_peer_timestamp, 
            sync_row_is_tombstone = sync_row_is_tombstone 						
		where order_id = p_order_id 			
		and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);
	else	
		update orders_tracking set
			update_scope_local_id = sync_scope_local_id, 
            scope_update_peer_key = sync_update_peer_key,
            scope_update_peer_timestamp = sync_update_peer_timestamp,
            local_update_peer_key = 0,
            local_update_peer_timestamp = sequence_timestamp.nextval,
            sync_row_is_tombstone = sync_row_is_tombstone 						
		where order_id = p_order_id 			
		and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);
  end if;
	sync_row_count := sql%rowcount;           	
  END;
END;
/	

create or replace
procedure sp_order_details_update_md (
		order_details_id IN int,
		sync_scope_local_id IN int,
        sync_row_is_tombstone IN int,
        sync_create_peer_key IN int ,
        sync_create_peer_timestamp IN number,                 
        sync_update_peer_key IN int,
        sync_update_peer_timestamp IN number,                      
        sync_row_timestamp IN number,
        sync_check_concurrency IN int,        
        sync_row_count OUT int)    
        
IS 
BEGIN
  DECLARE
    p_order_details_id int := order_details_id;
    was_tombstone INT;
  BEGIN
	select sync_row_is_tombstone into was_tombstone from order_details_tracking
	where order_details_id = p_order_details_id;
	
	if (was_tombstone is not null and was_tombstone=1 and sync_row_is_tombstone=0) then
		-- tombstone is getting resurrected, update creation version as well
		update order_details_tracking set
            update_scope_local_id = sync_scope_local_id, 
            scope_update_peer_key = sync_update_peer_key,
            scope_update_peer_timestamp = TO_NUMBER(sync_update_peer_timestamp),
            local_update_peer_key = 0,
            local_update_peer_timestamp = sequence_timestamp.nextval,
            create_scope_local_id = sync_scope_local_id, 
            scope_create_peer_key = sync_create_peer_key, 
            scope_create_peer_timestamp =  sync_create_peer_timestamp, 
            sync_row_is_tombstone = sync_row_is_tombstone 							
		where order_details_id = p_order_details_id 			
		and (sync_check_concurrency = 0 or local_update_peer_timestamp = TO_NUMBER(sync_row_timestamp));
	else	
		update order_details_tracking set
			update_scope_local_id = sync_scope_local_id, 
            scope_update_peer_key = sync_update_peer_key,
            scope_update_peer_timestamp = TO_NUMBER(sync_update_peer_timestamp),
            local_update_peer_key = 0,
            local_update_peer_timestamp = sequence_timestamp.nextval,
            sync_row_is_tombstone = sync_row_is_tombstone 								
		where order_details_id = p_order_details_id 			
		and (sync_check_concurrency = 0 or local_update_peer_timestamp = TO_NUMBER(sync_row_timestamp));
  end if;
	sync_row_count := sql%rowcount;           	
  END;
END;
/	

--
--  ***********************************************
--     Delete Procs for orders and order_details
--  ***********************************************
--

create or replace
procedure sp_orders_applydelete(
	order_id IN int ,	
	sync_min_timestamp IN number ,
	sync_force_write IN int, 	     	
	sync_row_count OUT int)	 
as  
BEGIN
  Declare
    p_order_id int := order_id;
  Begin
	delete
	from orders o 
  where o.order_id in 
    (select t.order_id from orders_tracking t
      where (t.local_update_peer_timestamp <= sync_min_timestamp  or sync_force_write = 1)      
      and t.order_id = p_order_id);  
	sync_row_count := sql%rowcount;
  END;
END;                 
/

create or replace
procedure sp_order_details_applydelete(
	order_details_id IN int ,	
  sync_min_timestamp IN number ,
	sync_force_write IN int, 	     	
	sync_row_count OUT int)	 
IS
  BEGIN
    DECLARE
      p_order_details_id int := order_details_id;
    BEGIN
      delete
      from order_details o 
      where o.order_details_id in 
        (select t.order_details_id from order_details_tracking t 
          where (t.local_update_peer_timestamp <= sync_min_timestamp or sync_force_write = 1)
          and t.order_details_id = p_order_details_id);
      sync_row_count := sql%rowcount;             
    END;
  END;
/

create or replace
procedure sp_orders_delete_md(
    order_id IN int ,			
    sync_row_timestamp IN number,	
    sync_check_concurrency IN int,	
    sync_row_count OUT int) 	
IS
BEGIN
  DECLARE
    p_order_id int := order_id;
  BEGIN
	-- delete metadata only
	delete
	from orders_tracking o
	where o.order_id = p_order_id and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);
	sync_row_count := sql%rowcount; 
  END;
END;
/

create or replace
procedure sp_order_details_delete_md(
    order_details_id IN int ,			
    sync_row_timestamp IN number,	
    sync_check_concurrency IN int,	
    sync_row_count OUT int) 	
IS
  BEGIN
    DECLARE
      p_order_details_id int := order_details_id;
    BEGIN
	-- delete metadata only
	delete
	from order_details_tracking o
	where o.order_details_id = p_order_details_id and (sync_check_concurrency = 0 or local_update_peer_timestamp = sync_row_timestamp);
	sync_row_count := sql%rowcount;  
    END;
END;         	
/

--
--  ***********************************************
--     Get conflicting row procs
--  ***********************************************
--

create or replace
procedure sp_orders_selectrow(
        p_order_id IN int,
        sync_scope_local_id IN int,
        selectedRow OUT sys_refcursor)
IS
BEGIN
open selectedRow for select  
            t.order_id,
            o.order_date, 
            t.sync_row_is_tombstone,
            t.local_update_peer_timestamp as sync_row_timestamp, 
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_timestamp else t.scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_key else t.scope_update_peer_key end as sync_update_peer_key,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_timestamp else t.scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_key else t.scope_create_peer_key end as sync_create_peer_key
    from orders o right join orders_tracking t on o.order_id = t.order_id    
    where t.order_id = p_order_id;
END;
/

create or replace
procedure sp_order_details_selectrow(
        order_details_id IN int,
        sync_scope_local_id IN int,
        selectedRow OUT sys_refcursor)
IS
BEGIN
  Declare
    p_order_details_id int := order_details_id;
  Begin
    open selectedRow for select	
                        t.order_details_id,
			o.order_id, 
			o.product, 
			o.quantity, 
            t.sync_row_is_tombstone,
            t.local_update_peer_timestamp as sync_row_timestamp, 
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_timestamp else t.scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (t.update_scope_local_id is null or t.update_scope_local_id <> sync_scope_local_id) 
                 then t.local_update_peer_key else t.scope_update_peer_key end as sync_update_peer_key,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_timestamp else t.scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (t.create_scope_local_id is null or t.create_scope_local_id <> sync_scope_local_id) 
                 then t.local_create_peer_key else t.scope_create_peer_key end as sync_create_peer_key
    from order_details o right join order_details_tracking t on o.order_details_id = t.order_details_id	
    where t.order_details_id = p_order_details_id;
  END;
END;
/
--
--  ***********************************************
--     Get tombstones for cleanup commands
--  ***********************************************
--

create or replace
procedure sp_orders_select_ts(     
	tombstone_aging_in_hours IN int,
	sync_scope_local_id IN int,
  tombstones OUT sys_refcursor)	
IS
BEGIN
	open tombstones for select	order_id,
			local_update_peer_timestamp as sync_row_timestamp,  
			case when (update_scope_local_id is null or update_scope_local_id <> sync_scope_local_id) 
                 then local_update_peer_timestamp else scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (update_scope_local_id is null or update_scope_local_id <> sync_scope_local_id) 
                 then local_update_peer_key else scope_update_peer_key end as sync_update_peer_key,
            case when (create_scope_local_id is null or create_scope_local_id <> sync_scope_local_id) 
                 then local_create_peer_timestamp else scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (create_scope_local_id is null or create_scope_local_id <> sync_scope_local_id) 
                 then local_create_peer_key else scope_create_peer_key end as sync_create_peer_key			
	from orders_tracking 
	where sync_row_is_tombstone=1 
	and (SYSDATE - last_change_datetime) > tombstone_aging_in_hours;
END;
/

create or replace
procedure sp_order_details_select_ts(  
	tombstone_aging_in_hours IN int,
	sync_scope_local_id IN int, 
  tombstones OUT sys_refcursor) 
  IS
  BEGIN
	open tombstones for select order_details_id,
			local_update_peer_timestamp as sync_row_timestamp, 
			case when (update_scope_local_id is null or update_scope_local_id <> sync_scope_local_id) 
                 then local_update_peer_timestamp else scope_update_peer_timestamp end as sync_update_peer_timestamp,
            case when (update_scope_local_id is null or update_scope_local_id <> sync_scope_local_id) 
                 then local_update_peer_key else scope_update_peer_key end as sync_update_peer_key,
            case when (create_scope_local_id is null or create_scope_local_id <> sync_scope_local_id) 
                 then local_create_peer_timestamp else scope_create_peer_timestamp end as sync_create_peer_timestamp,
            case when (create_scope_local_id is null or create_scope_local_id <> sync_scope_local_id) 
                 then local_create_peer_key else scope_create_peer_key end as sync_create_peer_key			
	from order_details_tracking 
	where sync_row_is_tombstone=1 
	and (SYSDATE - last_change_datetime) > tombstone_aging_in_hours;
END;	
/

create or replace
procedure sp_select_shared_scopes(
		sync_scope_name IN nvarchar2,
    shared_scopes OUT sys_refcursor)		
IS
BEGIN
	open shared_scopes for select scopeTableMap2.table_name as sync_table_name, 
			scopeTableMap2.scope_name as sync_shared_scope_name
	from scope_table_map scopeTableMap1 join scope_table_map scopeTableMap2
	on scopeTableMap1.table_name = scopeTableMap2.table_name
	and scopeTableMap1.scope_name = sync_scope_name
	where scopeTableMap2.scope_name <> sync_scope_name;
END;
/

create or replace
procedure sp_get_timestamp(sync_new_timestamp OUT int)
IS
BEGIN
	select sequence_timestamp.nextval into sync_new_timestamp from dual;
END;
/