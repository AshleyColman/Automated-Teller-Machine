using ATMLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.DataAccess
{
    public interface IDataAccess
    {
        const string ConnectionString = default;
        Task<IAccount> GetAccountByPinAsync(int _pin);
        Task InsertNewAccountAsync(IAccount account);
    }
}