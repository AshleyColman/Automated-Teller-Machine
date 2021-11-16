CREATE TABLE [dbo].[Accounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Pin] INT NOT NULL, 
    [Balance] DECIMAL NOT NULL
)
