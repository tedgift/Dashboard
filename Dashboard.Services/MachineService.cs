using Dashboard.Entites.Entities;

using Dashboard.RepositoriesContracts;
using Dashboard.Services.Validations;
using Dashboard.ServicesContracts.DataTransferObjects.Machines;
using Dashboard.ServicesContracts.Extensions;
using Dashboard.ServicesContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<MachineResponse> AddMachine(MachineAddRequest machineAddRequest)
        {
            if (machineAddRequest == null)
            {
                throw new ArgumentNullException(nameof(machineAddRequest));
            }

            ServicesValidation.ModelValidation(machineAddRequest);
            Machine machine = machineAddRequest.ToMachine();
            //machine.Id = 1;
            await _machineRepository.AddMachine(machine);
            return machine.ToMachineResponse();
        }

        public async Task<bool> DeleteMachine(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id));
            }
            Machine? machine = await _machineRepository.GetMachineById(id.Value);
            if (machine == null)
            {
                return false;
            }
            await _machineRepository.DeleteMachineById(id.Value);
            return true;
        }

        public async Task<List<MachineResponse>> GetFilteredMachine(string searchBy, string? searchString)
        {
            List<Machine> machines = searchBy switch
            {
                nameof(MachineResponse.Name) =>
                 await _machineRepository.GetFilteredMachines(machine =>
                 machine.Name.Contains(searchString)),

                _ => await _machineRepository.GetAllMachines()
            };
            return machines.Select(machine => machine.ToMachineResponse()).ToList();
        }

        public async Task<MachineResponse?> GetMachineById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Machine? machine = await _machineRepository.GetMachineById(id.Value);
            if (machine == null)
            {
                return null;
            }
            return machine.ToMachineResponse();
        }

      
        public async Task<List<MachineResponse>> GetAllMachines()
        {
            var machines = await _machineRepository.GetAllMachines();

            return machines
              .Select(machine => machine.ToMachineResponse()).ToList();
        }

        public async Task<MachineResponse> UpdateMachine(MachineUpdateRequest? machineUpdateRequest)
        {
            if (machineUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(machineUpdateRequest));
            }
            Validations.ServicesValidation.ModelValidation(machineUpdateRequest);
            Machine? matchMachine = await _machineRepository
                .GetMachineById(machineUpdateRequest.Id);
            if (matchMachine == null)
            {
                throw new ArgumentException("Machine does not exist");
            }

            matchMachine.Name = machineUpdateRequest.Name;
            matchMachine.Description = machineUpdateRequest.Description;
            matchMachine.Cluster = machineUpdateRequest.Cluster;
            await _machineRepository.UpdateMachine(matchMachine);
            return matchMachine.ToMachineResponse();
        }

        //public Task<bool> DeleteMachine(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
