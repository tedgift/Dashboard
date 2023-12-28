using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Entites.Entities;
using Dashboard.Entities.DbContexts;
using Dashboard.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteTransactionById(int id)
        {
            _context.Transactions.RemoveRange(_context.Transactions.Where(transaction => transaction.Id == id));
            int rowsDeleted = await _context.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetFilteredTransaction(Expression<Func<Transaction, bool>> predicate)
        {
            return await _context.Transactions.Where(predicate).ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == id);
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            Transaction matchedTransaction = await _context.Transactions.FirstOrDefaultAsync(transaction =>
            transaction.Id == transaction.Id);
            if (matchedTransaction == null) { return transaction; }

            matchedTransaction.Name = transaction.Name;

            int countUpdatedTransaction = await _context.SaveChangesAsync();
            return matchedTransaction;
        }
    }
}
