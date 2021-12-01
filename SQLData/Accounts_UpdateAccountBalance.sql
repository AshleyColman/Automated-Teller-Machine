CREATE PROCEDURE [dbo].[Accounts_UpdateAccountBalance]
	@Id INT,
	@Balance DECIMAL
AS
BEGIN
SET NOCOUNT ON 
	UPDATE dbo.Accounts
	SET Balance = @Balance
	WHERE Id = @Id
END