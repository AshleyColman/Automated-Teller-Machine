using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary.Classes;
using Dapper;

namespace ATMLibrary.DataAccess
{
    public sealed class SqlDataAccess : IDataAccess
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
            Integrated Security=True;
            Persist Security Info=False;
            Pooling=False;
            MultipleActiveResultSets=False;
            Connect Timeout=60;
            Encrypt=False;
            TrustServerCertificate=False";
        public async Task<IAccount> GetAccountByPinAsync(int _pin)
        {
            try
            {
                string procedure = "[AutomatedTellerMachineDB].[dbo].[Accounts_SelectAllAccountData]";
                var values = new { Pin = _pin };
                using IDbConnection connection = new SqlConnection(ConnectionString);
                return await connection.QuerySingleOrDefaultAsync<Account>(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception _ex)
            {
                throw new Exception(_ex.Message, _ex.InnerException);
            }
        }
        public async Task InsertNewAccountAsync(IAccount _account)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string procedure = "[AutomatedTellerMachineDB].[dbo].[Accounts_InsertNewAccount]";
                var values = new { FirstName = _account.FirstName, LastName = _account.LastName, 
                Pin = _account.Pin, Balance = _account.Balance };
                await connection.ExecuteAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.Message, _ex.InnerException);
            }
        }
        public async Task UpdateAccountBalanceAsync(IAccount _account)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string procedure = "[AutomatedTellerMachineDB].[dbo].[Accounts_UpdateAccountBalance]";
                var values = new
                {
                    Balance = _account.Balance
                };
                await connection.ExecuteAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.Message, _ex.InnerException);
            }
        }
    }
}
