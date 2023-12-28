using Dashboard.Entites.Entities;
using Dashboard.ServicesContracts.DataTransferObjects.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ServicesContracts.Extensions
{
    public static class MachineExtension
    {
        public static MachineResponse ToMachineResponse(this Machine machine)
        { 
            return new MachineResponse() { Id = machine.Id, Name = machine.Name, 
                Description = machine.Description, Cluster = machine.Cluster };
        }
    }
}
