using Dashboard.Entites.Entities;
using Dashboard.RepositoriesContracts;
using Dashboard.Services.Validations;
using Dashboard.ServicesContracts.DataTransferObjects.Transactions;
using Dashboard.ServicesContracts.Extensions;
using Dashboard.ServicesContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionResponse> AddTransaction(TransactionAddRequest transactionAddRequest)
        {
            if (transactionAddRequest == null)
            { 
                throw new ArgumentNullException(nameof(transactionAddRequest));
            }
            ServicesValidation.ModelValidation(transactionAddRequest);
            Transaction transaction = transactionAddRequest.ToTransaction();
            transaction.Id = 1;
            await _transactionRepository.AddTransaction(transaction);
            return transaction.ToTransactionResponse();
        }

        public async Task<bool> DeleteTransaction(int? id)
        {
            if (id==null)
            {
                throw new ArgumentException(nameof(id));
            }
            Transaction? transaction = await _transactionRepository.GetTransactionById(id.Value);
            if (transaction == null)
            {
                return false;
            }
            await _transactionRepository.DeleteTransactionById(id.Value);
            return true;
        }

        public async Task<List<TransactionResponse>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAllTransactions();
            return transactions.Select(transaction => transaction.ToTransactionResponse()).ToList();
        }

        public async Task<List<TransactionResponse>> GetFilteredTransaction(string searchBy, string? searchString)
        {
            List<Transaction> transactions = searchBy switch
            { 
                nameof(TransactionResponse.Name) =>
                await _transactionRepository.GetFilteredTransaction(transaction =>
                transaction.Name.Contains(searchString)),

                _ => await _transactionRepository.GetAllTransactions()
            };
            return transactions.Select(transaction => transaction.ToTransactionResponse()).ToList();
        }

        public async Task<TransactionResponse?> GetTransactionById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            await _transactionRepository.GetTransactionById(id.Value);
            Transaction? transaction = await _transactionRepository.GetTransactionById(id.Value);
            if (transaction == null)
            {
                return null;
            }
            return transaction.ToTransactionResponse();
        }

        public async Task<TransactionResponse> UpdateTransaction(TransactionUpdateRequest? transactionUpdateRequest)
        {
            if (transactionUpdateRequest == null)
            { 
                throw new ArgumentNullException(nameof(transactionUpdateRequest));
            }
            ServicesValidation.ModelValidation(transactionUpdateRequest);
            Transaction? matchTransaction = await _transactionRepository.GetTransactionById(transactionUpdateRequest.Id);
            if (matchTransaction == null)
            {
                throw new ArgumentException("Transaction doesn't exist");
            }
            matchTransaction.Name = transactionUpdateRequest.Name;
            await _transactionRepository.UpdateTransaction(matchTransaction);
            return matchTransaction.ToTransactionResponse();
        }
    }
}
