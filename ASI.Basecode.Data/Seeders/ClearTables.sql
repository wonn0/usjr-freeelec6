DECLARE @DynamicSQL NVARCHAR(MAX);

-- Disable all constraints
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all';

-- Initialize the variable to hold concatenated SQL.
SET @DynamicSQL = N'';

-- Select the names of all tables in the database excluding system tables
-- and concatenate the delete statement for each table.
SELECT @DynamicSQL = @DynamicSQL + 'DELETE FROM [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '];' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
AND TABLE_CATALOG = 'YourDatabaseName' -- Specify your database name here
AND TABLE_SCHEMA = 'dbo'; -- Specify your schema name here if different from dbo

-- Execute the delete statements for all tables.
EXEC sp_executesql @DynamicSQL;

-- Reseed the identity columns for all tables.
SELECT @DynamicSQL = N'';

SELECT @DynamicSQL = @DynamicSQL + 
    'IF OBJECTPROPERTY(OBJECT_ID(''[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']''), ''TableHasIdentity'') = 1 '
    + 'BEGIN DBCC CHECKIDENT (''[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']'', RESEED, 0); END;' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
AND TABLE_CATALOG = 'skoobydb' -- Specify your database name here
AND TABLE_SCHEMA = 'dbo'; -- Specify your schema name here if different from dbo

-- Execute the reseed statements for all tables with identity columns.
EXEC sp_executesql @DynamicSQL;

-- Re-enable all constraints
EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all';

