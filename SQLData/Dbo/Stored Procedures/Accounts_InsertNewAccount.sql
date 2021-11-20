CREATE PROCEDURE [dbo].[Accounts_InsertNewAccount]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Pin INT,
	@Balance DECIMAL
AS
BEGIN
SET NOCOUNT ON 
	INSERT INTO dbo.Accounts
	(FirstName, LastName, Pin, Balance)
	VALUES 
	(@FirstName, @LastName, @Pin, @Balance);
END