using Dashboard.Entites.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.DataTransferObjects.Transactions
{
    public class TransactionAddRequest
    {
        [Required]
        public string Name { get; set; }

        public Transaction ToTransaction()
        { 
            return new Transaction() { Name = Name };
        }
    }
}
