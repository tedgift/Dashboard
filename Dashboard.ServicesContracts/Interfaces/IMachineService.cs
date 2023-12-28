using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dashboard.ServicesContracts.DataTransferObjects.Machines;

namespace Dashboard.ServicesContracts.Interfaces
{
    public interface IMachineService
    {
        Task<MachineResponse> AddMachine(MachineAddRequest machineAddRequest);
        Task<List<MachineResponse>> GetAllMachines();
        Task<MachineResponse?> GetMachineById(int? id);
        Task<List<MachineResponse>> GetFilteredMachine(string searchBy, string? searchString);
  
        Task<MachineResponse> UpdateMachine(MachineUpdateRequest? machineUpdateRequest);
        Task<bool> DeleteMachine(int? id);

      
    }
}
