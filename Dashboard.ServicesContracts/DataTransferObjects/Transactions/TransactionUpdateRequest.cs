using Dashboard.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.DataTransferObjects.Transactions
{
    public class TransactionUpdateRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction() { Id = Id, Name = Name };
        }
    }
}
