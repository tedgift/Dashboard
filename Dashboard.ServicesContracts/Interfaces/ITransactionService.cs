using Dashboard.ServicesContracts.DataTransferObjects.Machines;

using Dashboard.ServicesContracts.DataTransferObjects.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.Interfaces
{
    public interface ITransactionService
    {
      
        Task<TransactionResponse> AddTransaction(TransactionAddRequest transactionAddRequest);
        Task<List<TransactionResponse>> GetAllTransactions();
        Task<TransactionResponse?> GetTransactionById(int? id);
        Task<List<TransactionResponse>> GetFilteredTransaction(string searchBy, string? searchString);
        Task<TransactionResponse> UpdateTransaction(TransactionUpdateRequest? transactionUpdateRequest);
        Task<bool> DeleteTransaction(int? id);
    }
}
