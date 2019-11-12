
DROP TABLE orders;
DROP TABLE order_details;
DROP TABLE scope_info;
DROP TABLE scope_table_map;
DROP TABLE orders_tracking;
DROP TABLE order_details_tracking;
DROP SEQUENCE sequence_newid;
DROP SEQUENCE sequence_timestamp;

CREATE TABLE orders(order_id int NOT NULL primary key, order_date date NULL);

CREATE TABLE order_details(order_id int NOT NULL, order_details_id int NOT NULL primary key, product nvarchar2(100) NULL, quantity int NULL);

--
-- Create scope info table
--
    
CREATE TABLE scope_info(scope_local_id int, scope_id RAW(16) UNIQUE, scope_name nvarchar2(100) NOT NULL PRIMARY KEY, scope_sync_knowledge blob NULL,scope_forgotten_knowledge blob NULL, scope_timestamp number, scope_cleanup_timestamp number);

CREATE SEQUENCE sequence_newid;
CREATE SEQUENCE sequence_timestamp;

--
-- Create scope table mapping table
--
CREATE TABLE scope_table_map(    	
    scope_name nvarchar2(100) ,
    table_name nvarchar2(100)     
    );

create unique index clustered_scope_table_map on scope_table_map(scope_name, table_name);

--
-- Create tracking tables
--
CREATE TABLE orders_tracking(
    order_id int NOT NULL primary key,
    update_scope_local_id int NULL, 
    scope_update_peer_key int,
    scope_update_peer_timestamp number,
    local_update_peer_key int,
    local_update_peer_timestamp number,
    create_scope_local_id int NULL,
    scope_create_peer_key int,
    scope_create_peer_timestamp number,
    local_create_peer_key int,
    local_create_peer_timestamp number,
    sync_row_is_tombstone int, 
    touch_timestamp timestamp, 
    last_change_datetime date default NULL
    );
 
--
-- Create index on tracking table
--
CREATE INDEX NC_Orders_tracking_ts_index
ON orders_tracking(local_update_peer_timestamp);
 
 
--
-- Create tracking tables
--
CREATE TABLE order_details_tracking(
	order_details_id int NOT NULL primary key,    
    update_scope_local_id int NULL, 
    scope_update_peer_key int,
    scope_update_peer_timestamp number,
    local_update_peer_key int,
    local_update_peer_timestamp number,
    create_scope_local_id int NULL,
    scope_create_peer_key int,
    scope_create_peer_timestamp number,
    local_create_peer_key int,
    local_create_peer_timestamp number,
    sync_row_is_tombstone int, 
    touch_timestamp timestamp, 
    last_change_datetime date default NULL
	);

--
-- Create index on tracking table
--
CREATE INDEX order_details_tracking_index
ON order_details_tracking (local_update_peer_timestamp);


-- 
-- Create Triggers
--

-- insert triggers

CREATE TRIGGER newid_trigger
before insert on scope_info
for each row
begin
  select sequence_newid.nextval into :new.scope_local_id from dual;
  select SYS_GUID into :new.scope_id from dual;
  select sequence_timestamp.nextval into :new.scope_timestamp from dual;
end;
/

-- inserts a new metadata row if one does not exist
-- if the row existed before and was deleted, the tombstone row is got back live.
create or replace
TRIGGER orders_insert_trigger AFTER INSERT ON orders referencing new AS newRow 
FOR EACH ROW 

-- NOTE: order of UPDATE, INSERT below is important
-- resurrect the tombstone row, do not update creation version
BEGIN
update orders_tracking ot 
    set 
      sync_row_is_tombstone = 0, local_update_peer_key = 0, 
      local_update_peer_timestamp = sequence_timestamp.nextval, update_scope_local_id = NULL, last_change_datetime = current_date
    where ot.order_id = :newRow.order_id;
    
    insert into orders_tracking
                (order_id, create_scope_local_id, 
		local_create_peer_key, local_create_peer_timestamp, 
		update_scope_local_id, local_update_peer_key, 
		local_update_peer_timestamp, sync_row_is_tombstone, last_change_datetime)
      values (:newRow.order_id, NULL, 0, sequence_timestamp.nextval, NULL, 0, sequence_timestamp.nextval, 0, current_date);
    EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;
END;
/

create or replace
TRIGGER order_details_insert_trigger AFTER INSERT ON order_details referencing new AS newRow
  for each row  
	-- NOTE: order of UPDATE, INSERT below is important
	-- resurrect the tombstone row, do not update creation version
  BEGIN
	update order_details_tracking odt 
	set 
		sync_row_is_tombstone = 0, local_update_peer_key = 0, 
		local_update_peer_timestamp = sequence_timestamp.nextval, update_scope_local_id = NULL, 
		last_change_datetime = current_date
	where  odt.order_details_id = :newRow.order_details_id;
	
	insert into order_details_tracking(order_details_id, create_scope_local_id, 
		local_create_peer_key, local_create_peer_timestamp, 
		update_scope_local_id, local_update_peer_key, 
		local_update_peer_timestamp, sync_row_is_tombstone, last_change_datetime)
    values (:newRow.order_details_id, NULL, 0, sequence_timestamp.nextval, NULL, 0, sequence_timestamp.nextval, 0, current_date);
    EXCEPTION WHEN DUP_VAL_ON_INDEX THEN NULL;
  END;
/

-- update triggers

-- update trigger sets the update_timestamp (gets automatically updated) and last_change_datetime values
create or replace
TRIGGER orders_update_trigger AFTER UPDATE ON orders REFERENCING NEW as newRow
  for each row    
  BEGIN
    update orders_tracking t    
	set 
		update_scope_local_id = NULL, local_update_peer_key = 0, 
		local_update_peer_timestamp = sequence_timestamp.nextval, last_change_datetime = current_date 
	where t.order_id = :newRow.order_id;  	
  END; 	
/

create or replace
TRIGGER order_details_update_trigger AFTER UPDATE ON order_details REFERENCING NEW as newRow
  for each row
  BEGIN
    update order_details_tracking t    
	set 
		update_scope_local_id = NULL, local_update_peer_key = 0, 
		local_update_peer_timestamp = sequence_timestamp.nextval, last_change_datetime = current_date 
	where t.order_details_id = :newRow.order_details_id;    	
  END;  	
/

-- delete triggers

-- delete trigger sets update_timestamp (gets automatically updated) and marks the row as deleted
create or replace
TRIGGER orders_delete_trigger AFTER DELETE ON orders REFERENCING OLD AS oldRow
for each row
    update orders_tracking t 
        set 
			sync_row_is_tombstone = 1, update_scope_local_id = NULL, 
			local_update_peer_key = 0, local_update_peer_timestamp = sequence_timestamp.nextval,
			last_change_datetime = current_date 
        where t.order_id = :oldRow.order_id    
/

create or replace
TRIGGER order_details_delete_trigger AFTER DELETE ON order_details REFERENCING OLD AS oldRow
for each row
    update order_details_tracking t 
        set 
			sync_row_is_tombstone = 1, update_scope_local_id = NULL, 
			local_update_peer_key = 0, local_update_peer_timestamp = sequence_timestamp.nextval,
			last_change_datetime = current_date 
       where t.order_details_id = :oldRow.order_details_id
/
