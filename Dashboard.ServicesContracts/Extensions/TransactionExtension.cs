using Dashboard.Entites.Entities;
using Dashboard.ServicesContracts.DataTransferObjects.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.Extensions
{
    public static class TransactionExtension
    {
        public static TransactionResponse ToTransactionResponse(this Transaction transaction)
        {
            return new TransactionResponse() { Id = transaction.Id, Name = transaction.Name };
        }
    }
}
