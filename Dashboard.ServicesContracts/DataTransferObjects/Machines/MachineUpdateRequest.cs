using Dashboard.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.DataTransferObjects.Machines
{
    public class MachineUpdateRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Cluster { get; set; }
        //public Status? Status { get; set; }
        public Machine ToMachine()
        {
            return new Machine() { Cluster = Cluster, Name = Name, Description = Description};
        }
    }
}
