using Dashboard.Entites.Entities;
using Dashboard.Entities.DbContexts;
using Dashboard.ServicesContracts.DataTransferObjects.Machines;
using Dashboard.ServicesContracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : CustomControllerBase
    {
       
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
           
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineResponse>>> GetMachines()
        {
            var machines = await _machineService.GetAllMachines();
            
            return machines;
        }
        [HttpGet("{machineID}")]
        public async Task<ActionResult<MachineResponse>> GetMachine(int machineID)
        {
            var machine = await _machineService.GetMachineById(machineID);
         

            if (machine == null)
            {
                return Problem(detail: "Invalid machineID", statusCode: 400, title: "Machine Search");
            
            }

            return machine;
        }

        //put is edit/update
        [HttpPut("{machineID}")]
        public async Task<IActionResult> PutMachine(int machineID, [Bind(nameof(Machine.Id), 
            nameof(Machine.Name), nameof(Machine.Description), nameof(Machine.Cluster))] MachineUpdateRequest machine)
        {
            if (machineID != machine.Id)
            {
                return BadRequest(); //HTTP 400
            }
        
            var existingMachine = await _machineService.UpdateMachine(machine);
            if (existingMachine == null)
            {
                return NotFound(); //HTTP 404
            }          
            return NoContent();                     
        }
        //private bool machineExists(int id)
        //{
        //    return (_context.Machines?.Any(machine =>
        //    machine.Id == id)).GetValueOrDefault();
        //}
        //insert//create
        [HttpPost]
        public async Task<ActionResult<MachineResponse>> PostCity([Bind(nameof(Machine.Id), nameof(Machine.Name)
            ,nameof(Machine.Description), nameof(Machine.Cluster))] MachineAddRequest machine)
        {
  
            if (_machineService.AddMachine == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Machines'  is null.");
            }
            return await _machineService.AddMachine(machine);

            //return CreatedAtAction("GetMachine", new { machi }, machine);
            //return CreatedAtAction("GetMachine", new { machineId =  }, machine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var hasDeleted = await _machineService.DeleteMachine(id);
            //var machine = await _context.Machines.FindAsync(id);
            if (!hasDeleted)
            {
                return NotFound(); //HTTP 404
            }

            //_context.Machines.Remove(machine);
            //await _context.SaveChangesAsync();

            return NoContent(); //HTTP 200
        }


     
    }
}
