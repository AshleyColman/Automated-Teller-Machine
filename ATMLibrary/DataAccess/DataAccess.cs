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
    public static class DataAccess
    {
        private const string ConnectionString = "";
        public static async Task<Account> GetAccount(string _lastName)
        {
            string query = "dbo.Accounts_SelectAllAccountData @FirstName";
            using IDbConnection connection = new SqlConnection(ConnectionString);
            return await connection.QuerySingleAsync<Account>(query, new { LastName = _lastName });
        }
    }
}
