
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.DataTransferObjects.Transactions
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj.GetType() != typeof(TransactionResponse)) return false;

            TransactionResponse status = (TransactionResponse)obj;
            return Id == status.Id && Name == status.Name;


        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
        public TransactionUpdateRequest ToTransactionUpdateRequest()
        {
            return new TransactionUpdateRequest() { Id = Id, Name = Name };
        }
    }
}
