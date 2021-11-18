CREATE PROCEDURE [dbo].[Accounts_SelectAllAccountData]
	@Pin int
AS
BEGIN
SET NOCOUNT ON;
	SELECT *
	FROM dbo.Accounts
	WHERE Pin = @Pin
END