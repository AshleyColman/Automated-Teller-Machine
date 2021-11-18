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
        public async Task<IAccount> GetAccountByPin(int _pin)
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
    }
}
