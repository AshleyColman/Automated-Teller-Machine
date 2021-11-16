CREATE PROCEDURE [dbo].[spAccounts_SelectAllAccountData]
	@FirstName nvarchar(50)
AS
BEGIN
SET NOCOUNT ON
	SELECT *
	FROM dbo.Accounts
	WHERE FirstName = @FirstName
END