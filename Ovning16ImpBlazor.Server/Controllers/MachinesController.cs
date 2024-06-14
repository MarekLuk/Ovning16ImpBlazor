using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ovning16ImpBlazor.Server;
using Ovning16ImpBlazor.Server.Data;

namespace Ovning16ImpBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        //    private static List<Machine> _machines = new List<Machine>
        //{

        //    new Machine { Id = Guid.NewGuid(), Name = "Excavator", Color = "Yellow", Speed = 45, IsOnline = true, LatestDataSent = DateTime.Now },

        //};

        private static List<Machine> _machines = GenerateFakeMachines(5); 

        private static List<Machine> GenerateFakeMachines(int count)
        {
            
            var machineFaker = new Faker<Machine>()
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Name, f => f.Commerce.ProductName())
                .RuleFor(m => m.Color, f => f.Commerce.Color())
                .RuleFor(m => m.Speed, f => f.Random.Int(10, 100))
                .RuleFor(m => m.IsOnline, f => f.Random.Bool())
                .RuleFor(m => m.LatestDataSent, f => f.Date.Recent(30));

            return machineFaker.Generate(count);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Machine>> GetMachines()
        {
            return Ok(_machines);
        }

        [HttpGet("{id}")]
        public ActionResult<Machine> GetMachine(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine == null) return NotFound();
            return Ok(machine);
        }

        [HttpPost]
        public ActionResult<Machine> PostMachine([FromBody] Machine machine)
        {
            machine.Id = Guid.NewGuid();
            _machines.Add(machine);
            return CreatedAtAction(nameof(GetMachine), new { id = machine.Id }, machine);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMachine(Guid id, [FromBody] Machine machine)
        {
            var existingMachine = _machines.FirstOrDefault(m => m.Id == id);
            if (existingMachine == null) return NotFound();

            existingMachine.Name = machine.Name;
            existingMachine.Color = machine.Color;
            existingMachine.Speed = machine.Speed;
            existingMachine.IsOnline = machine.IsOnline;
            existingMachine.LatestDataSent = DateTime.Now;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMachine(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine == null) return NotFound();

            _machines.Remove(machine);
            return NoContent();
        }
    }
}