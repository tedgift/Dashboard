using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Entites.Entities;


namespace Dashboard.ServicesContracts.DataTransferObjects.Machines
{
    public class MachineAddRequest
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Cluster { get; set; }
        //[Required]
        //public Status? Status { get; set; }

        public Machine ToMachine()
        {
            return new Machine() { Cluster = Cluster, Name = Name, Description = Description };
        }
    }
}
