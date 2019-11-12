-- =============================================                               
-- Author      : Shanu                                
-- Create date : 2015-07-13                                 
-- Description : To Create Database,Table and Sample Insert Query                            
-- Latest                               
-- Modifier    : Shanu                                
-- Modify date : 2015-07-13                           
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER
GO

-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'projectDB' )
DROP DATABASE projectDB
GO

CREATE DATABASE projectDB
GO

USE projectDB
GO


CREATE TABLE [dbo].[SCHED_Master](
	[ID] [int] NOT NULL,
	[ProjectName] [varchar](100) NULL,
	[ProjectType] int NULL,
	[ProjectTypeName] [varchar](100) NULL,
	[SCHED_ST_DT] [datetime] NULL,
	[SCHED_ED_DT] [datetime] NULL,	
	[ACT_ST_DT] [datetime] NULL,
	[ACT_ED_DT] [datetime] NULL,
	[status] int null
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

-- Insert Query



INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1001,'Project1',1,'Urgent','2015-06-01 00:00:00.000','2015-09-02 00:00:00.000'
            ,'2015-06-22 00:00:00.000','2015-08-26 00:00:00.000',1)


INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1002,'Project1',2,'Important','2015-09-22 00:00:00.000','2015-12-22 00:00:00.000'
            ,'2015-09-19 00:00:00.000','2015-12-29 00:00:00.000',1)

INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1003,'Project1',3,'Normal','2016-01-01 00:00:00.000','2016-03-24 00:00:00.000'
            ,'2016-01-01 00:00:00.000','2016-03-14 00:00:00.000',1)


INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1004,'Project2',1,'Urgent','2015-07-01 00:00:00.000','2015-09-02 00:00:00.000'
            ,'2015-07-22 00:00:00.000','2015-08-26 00:00:00.000',1)


INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1005,'Project2',2,'Important','2015-09-29 00:00:00.000','2015-12-22 00:00:00.000'
            ,'2015-09-08 00:00:00.000','2015-12-14 00:00:00.000',1)

INSERT INTO [dbo].SCHED_Master
           ([ID],[ProjectName],[ProjectType],[ProjectTypeName],[SCHED_ST_DT],[SCHED_ED_DT],[ACT_ST_DT],[ACT_ED_DT],[status])
     VALUES
           (1006,'Project2',3,'Normal','2016-01-01 00:00:00.000','2016-03-04 00:00:00.000'
            ,'2016-01-01 00:00:00.000','2016-02-24 00:00:00.000',1)


-- Select Query

select ID,ProjectName,ProjectType,ProjectTypeName,SCHED_ST_DT,SCHED_ED_DT,ACT_ST_DT,ACT_ED_DT,status from SCHED_Master


-- =============================================                                                                      
-- Author      : Shanu                                                                      
-- Create date : 2015-07-24                                                                      
-- Description : To get all prject Schedule details                                                                     
-- Latest                                                                      
-- Modifier    : Shanu                                                                      
-- Modify date : 2015-07-24                                                                      
-- =============================================                                                                      
--  usp_ProjectSchedule_Select 'Project1'               
--  usp_ProjectSchedule_Select ''                                                                
-- =============================================                                                                 
Alter PROCEDURE [dbo].[usp_ProjectSchedule_Select]                                                    
@projectId           VARCHAR(10)  = ''                                                                 
                                                         
AS                                                                      
BEGIN                                                       
     
 -- 1. Declared for setting the Schedule Start and End date
 --1.Start /////////////
  Declare   @FromDate          VARCHAR(20)  = '2015-06-08'--DATEADD(mm,-12,getdate())                                                           
  Declare   @ToDate            VARCHAR(20)  = '2016-05-06'--DATEADD(mm, 1, getdate())  
  -- used for the pivot table result
  DECLARE @MyColumns AS NVARCHAR(MAX),
    @SQLquery  AS NVARCHAR(MAX)     
  --// End of 1.
  
  -- 2.This Temp table is to created for  get all the days between the start date and end date to display as the Column Header                                                      
 --2.Start /////////////                                                                
 IF OBJECT_ID('tempdb..#TEMP_EveryWk_Sndays') IS NOT NULL                                                                          
    DROP TABLE #TEMP_EveryWk_Sndays                                                                       
                                                                          
 DECLARE @TOTALCount INT                                          
    Select  @TOTALCount= DATEDIFF(dd,@FromDate,@ToDate);           
   WITH d AS                                                                       
            (                                                                      
              SELECT top (@TOTALCount) AllDays = DATEADD(DAY, ROW_NUMBER()                                                                       
                OVER (ORDER BY object_id), REPLACE(@FromDate,'-',''))                                                                      
              FROM sys.all_objects                                             
            )                                                                      
                                                                            
         SELECT  distinct DATEADD(DAY, 1 - DATEPART(WEEKDAY, AllDays), CAST(AllDays AS DATE))WkStartSundays  ,1 as status                                                              
                                                                           
 into #TEMP_EveryWk_Sndays                                                                    
    FROM d                             
   where                          
        AllDays  <= @ToDate                                      
   AND AllDays  >= @FromDate        
   
   -- test the sample temptable with select query
  -- select * from #TEMP_EveryWk_Sndays
   --///////////// End of 2.
   
   -- 3. This temp table is created toScedule details with result here i have used the Union ,
   --the 1st query return the Schedule Project result and the 2nd query returns the Actual Project result both this query will be inserted to a Temp Table
 --3.Start /////////////
 IF OBJECT_ID('tempdb..#TEMP_results') IS NOT NULL                                                                          
    DROP TABLE #TEMP_results   
 
	   SELECT ProjectName,viewtype,ProjectType,resultnew,YMWK
	   INTO #TEMP_results
	   FROM(
				SELECT                                                                
						 A.ProjectName ProjectName   -- Our Project Name                                       
						,'1-Scd' viewtype            -- Our View type first we display Schedule Data and then Actual                                                 
						, A. ProjectType ProjectType -- Our Project type here you can use your own status as Urgent,normal and etc 
						,  Case when   cast(DATEPART( wk, max(A.SCHED_ED_DT)) as varchar(2)) =  cast(DATEPART( wk, WkStartSundays) as varchar(2))  then -1 else
							case when min(A.SCHED_ST_DT)<= F.WkStartSundays AND max(A.SCHED_ED_DT) >= F.WkStartSundays                                                        
						  then 1 else 0  end end resultnew  -- perfectResult as i expect   
					    ,  RIGHT(YEAR(WkStartSundays), 2)+'-'+'W'+convert(varchar(2),Case when len(DATEPART( wk, WkStartSundays))='1' then '0'+                                
						  cast(DATEPART( wk, WkStartSundays) as varchar(2)) else cast(DATEPART( wk, WkStartSundays) as varchar(2)) END                             
						  ) as 'YMWK'  -- Here we display Year/month and Week of our Schedule which will be displayed as the Column                 

			  FROM   -- here you can youe your own table                                                          
						 SCHED_Master A (NOLOCK)       
								 LEFT OUTER JOIN 
						 #TEMP_EveryWk_Sndays F (NOLOCK)  ON A.status= F.status                                                            
			                                          
				WHERE  -- Here you can check your own where conditions     
						A.ProjectName like '%' + @projectId                                                      
					AND	A.status=1                                                                          
					AND A.ProjectType in (1,2,3) 
					AND A.SCHED_ST_DT  <= @ToDate                                          
				    AND A.SCHED_ED_DT  >= @FromDate  
				GROUP BY                                                             
					   A.ProjectName                                                         
					 , A. ProjectType  
					 ,A.SCHED_ED_DT                   
					,F.WkStartSundays

	UNION  -- This query is to result the Actual result
			SELECT                                                                
						 A.ProjectName ProjectName   -- Our Project Name                                       
						,'2-Act' viewtype            -- Our View type first we display Schedule Data and then Actual                                                 
						, A. ProjectType ProjectType -- Our Project type here you can use your own status as Urgent,normal and etc 
						,  Case when   cast(DATEPART( wk, max(A.ACT_ED_DT)) as varchar(2)) =  cast(DATEPART( wk, WkStartSundays) as varchar(2))  then -1 else
							case when min(A.ACT_ST_DT)<= F.WkStartSundays AND max(A.ACT_ED_DT) >= F.WkStartSundays                                                        
						   then 2 else 0  end end resultnew  -- perfectResult as i expect 
						
					    , RIGHT(YEAR(WkStartSundays), 2)+'-'+'W'+convert(varchar(2),Case when len(DATEPART( wk, WkStartSundays))='1' then '0'+                                
							  cast(DATEPART( wk, WkStartSundays) as varchar(2)) else cast(DATEPART( wk, WkStartSundays) as varchar(2)) END                             
							  ) as 'YMWK'  -- Here we display Year/month and Week of our Schedule which will be displayed as the Column                 

			  FROM   -- here you can youe your own table                                                          
						 SCHED_Master A (NOLOCK)       
								 LEFT OUTER JOIN 
						 #TEMP_EveryWk_Sndays F (NOLOCK)  ON A.status= F.status                                                            
			                                          
				WHERE  -- Here you can check your own where conditions      
						A.ProjectName like '%' + @projectId                                                     
					AND	A.status=1                                                                          
					AND A.ProjectType in (1,2,3) 
					AND A.ACT_ST_DT  <= @ToDate                                          
				    AND A.ACT_ED_DT  >= @FromDate  
				GROUP BY                                                             
					   A.ProjectName                                                         
					 , A. ProjectType  
					 ,A.SCHED_ED_DT                   
					,F.WkStartSundays

	 )  q                 

 --3.End /////////////

 --4.Start /////////////
 
 --here first we get all the YMWK which should be display in Columns we use this in our next pivot query
select @MyColumns = STUFF((SELECT ',' + QUOTENAME(YMWK) 
                    FROM #TEMP_results
                    GROUP BY YMWK
                    ORDER BY YMWK
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
 --here we use the above all YMWK  to disoplay its result as column and row display
set @SQLquery = N'SELECT ProjectName,viewtype,ProjectType,' + @MyColumns + N' from 
             (
                 SELECT 
       ProjectName, 
       viewtype,
       ProjectType,
       YMWK,
        resultnew as resultnew 
    FROM #TEMP_results
            ) x
            pivot 
            (
                 sum(resultnew)
                for YMWK in (' + @MyColumns + N')
            ) p  order by ProjectName, ProjectType,viewtype'

exec sp_executesql @SQLquery;
                                   
END