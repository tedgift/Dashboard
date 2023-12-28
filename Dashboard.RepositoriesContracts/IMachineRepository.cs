using Dashboard.Entites.Entities;
using Dashboard.ServicesContracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Dashboard.RepositoriesContracts
{
    public interface IMachineRepository
    {
        Task<Machine> AddMachine(Machine machine);
        Task<List<Machine>> GetAllMachines();
        Task<Machine?> GetMachineById(int id);
        Task<List<Machine>> GetFilteredMachines(Expression<Func<Machine, bool>> predicate);
        Task<bool> DeleteMachineById(int id);
        Task<Machine> UpdateMachine(Machine machine);
    }
}
