# advcsharp-lu9
Repository for Advanced C# Learning Unit 9 Group Project


DIRECTIONS FOR CREATING DATABASE
#
#	Step 1: Open SQL Server Object Explorer
#
#	Step 2: Navagate to SQLServer\(localdb)\MSSQLLocalDB\Databases
#
#	Step 3: Right click on the Databases folder, and click "Add New Database"
#
#	Step 4: Name the database "GPDB1"
#
#	Step 5: Click the ok button
#
#	Step 6: Next, navagate to SQLServer\(localdb)\MSSQLLocalDB\Databases\GPDB1
#
#	Step 7: Right click on the "Tables" folder, and click "Add New Table"
#
#	Step 8: Enter the names and datatypes of the variables for the game table
#	varchar(50) name, decimal(10,2) price, decimal(10,2) revenue, int numberOfPlayers, varchar(MAX) platforms
#	DateTime releaseDate, In the lower half of the screen, on the first line of the create statment,
#	Change CREATE TABLE [dbo].[Table], to CREATE TABLE [dbo].[game]
#	Then on Line 2 in the editer, change...
#	[Id]              INT             NOT NULL,
#	Into...
#	[Id]              INT             NOT NULL Identity(1,1),
#
#	Step 9: In the upper left corner of the screen click the "Update" button. A new window will appear.
#	Now click on the "Update Database" button. This will save the table to the database.
#
#	Step 10: Now add the merch table, Right click on the "Tables" folder, and click "Add New Table"
#
#	Step 11: Enter the names and datatypes of the variables for the merch table
#	varchar(50) itemName, varchar(MAX) itemDescription, int itemInStock, decimal(10,2) itemPrice
#	In the lower half of the screen, on the first line of the create statment,
#	Change CREATE TABLE [dbo].[Table], to CREATE TABLE [dbo].[merch]
#
#	Step 12: In the upper left corner of the screen click the "Update" button. A new window will appear.
#	Now click on the "Update Database" button. This will save the table to the database.
#
#	The Database should now be complete.