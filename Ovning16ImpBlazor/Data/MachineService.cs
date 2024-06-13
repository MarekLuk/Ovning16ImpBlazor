using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning16ImpBlazor.Data
{
    public class MachineService
    {
        private static readonly string[] ExamplesOfMachines = new[]
        {
            "Car", "Truck", "Motorbike", "Tanker", "Tractor", "Pickup", "Forklift", "Transporter", "Cementmixer", "Crane", "Excavator"
        };

        private static readonly string[] ColorOfMachine = new[]
        {
            "Red", "Green", "Blue", "Yellow", "Brown", "White"
        };

        private List<Machine> machines = new List<Machine>();

        public Task<Machine[]> GetMachinesAsync()
        {
            return Task.FromResult(machines.ToArray());
        }

        public Task AddMachineAsync(Machine machine)
        {
            machines.Add(machine);
            return Task.CompletedTask;
        }
        public Task DeleteMachineAsync(Guid id)
        {
            var machine = machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machines.Remove(machine);
            }
            return Task.CompletedTask;
        }

        public Task UpdateMachineAsync(Machine updatedMachine)
        {
            var machine = machines.FirstOrDefault(m => m.Id == updatedMachine.Id);
            if (machine != null)
            {
                machine.Name = updatedMachine.Name;
                machine.Color = updatedMachine.Color;
                machine.Speed = updatedMachine.Speed;
                machine.LatestDataSent = updatedMachine.LatestDataSent;
                machine.IsOnline = updatedMachine.IsOnline;
            }
            return Task.CompletedTask;
        }

        public Task<Machine[]> GetForecastAsync(DateTime startDate)
        {
            var newMachines = Enumerable.Range(1, 5).Select(index => new Machine
            {
                Id = Guid.NewGuid(),
                LatestDataSent = startDate.AddDays(index),
                Speed = Random.Shared.Next(1, 99),
                Color = ColorOfMachine[Random.Shared.Next(ColorOfMachine.Length)],
                IsOnline = Random.Shared.NextDouble() >= 0.5,
                Name = ExamplesOfMachines[Random.Shared.Next(ExamplesOfMachines.Length)]
            }).ToArray();

            machines.AddRange(newMachines);
            return Task.FromResult(newMachines);
        }
    }
}
