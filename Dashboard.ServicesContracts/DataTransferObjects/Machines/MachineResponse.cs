using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dashboard.ServicesContracts.DataTransferObjects.Machines
{
    public class MachineResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Cluster { get; set; }
        //public Status? Status { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj.GetType() != typeof(MachineResponse)) return false;

            MachineResponse machine = (MachineResponse)obj;
            return Id == machine.Id && Name == machine.Name &&
                Description == machine.Description && Cluster == machine.Cluster;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Cluster: {Cluster}";
        }
        public MachineUpdateRequest ToMachineUpdateRequest()
        {
            return new MachineUpdateRequest() { Cluster = Cluster, Name = Name, Description = Description };
        }
    }
}
