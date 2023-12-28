using Dashboard.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.RepositoriesContracts
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task<List<Transaction>> GetFilteredTransaction(Expression<Func<Transaction, bool>> predicate);
        Task<bool> DeleteTransactionById(int id);
        Task<Transaction> UpdateTransaction(Transaction transaction);
    }
}
