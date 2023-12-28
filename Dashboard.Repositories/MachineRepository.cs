using Dashboard.Entities.DbContexts;
using Dashboard.RepositoriesContracts;
using Dashboard.ServicesContracts.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Machine = Dashboard.Entites.Entities.Machine;

namespace Dashboard.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly ApplicationDbContext _context;

        public MachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Machine> AddMachine(Machine machine)
        {

            _context.CreateMachine(machine);
            await _context.SaveChangesAsync();
            return machine;
            //_context.Add(machine);
            //await _context.SaveChangesAsync();
            //return machine;
        }

        public async Task<bool> DeleteMachineById(int id)
        {
            _context.DeleteMachine(id);
            //_context.Machines.RemoveRange(_context.Machines.Where(machine => machine.Id == id));
            int rowsDeleted = await _context.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<List<Machine>> GetAllMachines()
        {
            return await _context.Machines.ToListAsync();
        }

        public async Task<List<Machine>> GetFilteredMachines(Expression<Func<Machine, bool>> predicate)
        {
            return await _context.Machines.Where(predicate).ToListAsync();
        }

        public async Task<Machine?> GetMachineById(int id)
        {
            return await _context.GetMachineById(id);
        
            //return await _context.Machines.FirstOrDefaultAsync(machine => machine.Id == id);
        }

        public async Task<Machine> UpdateMachine(Machine machine)
        {
            
            //Machine matchingMachine = await _context.
            Machine matchedMachine = await _context.Machines.FirstOrDefaultAsync(machine =>
          machine.Id == machine.Id);
            if (matchedMachine == null) { return machine; }

            _context.UpdateMachine(machine);

            int countUpdatedMachine = await _context.SaveChangesAsync();
            return matchedMachine;
        }
    }
}
