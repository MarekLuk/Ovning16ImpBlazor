using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Ovning16ImpBlazor.Data
{
    public class MachineService
    {
        //private static readonly string[] ExamplesOfMachines = new[]
        //{
        //    "Car", "Truck", "Motorbike", "Tanker", "Tractor", "Pickup", "Forklift", "Transporter", "Cementmixer", "Crane", "Excavator"
        //};

        //private static readonly string[] ColorOfMachine = new[]
        //{
        //    "Red", "Green", "Blue", "Yellow", "Brown", "White"
        //};

        //private List<Machine> machines = new List<Machine>();

        private readonly HttpClient _httpClient;

        public MachineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<Machine[]> GetMachinesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Machine[]>("api/machines");
            }
            catch
            {
                return Array.Empty<Machine>();
            }
        }

        public async Task AddMachineAsync(Machine machine)
        {
            var response = await _httpClient.PostAsJsonAsync("api/machines", machine);
            response.EnsureSuccessStatusCode();
        }



        public async Task DeleteMachineAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/machines/{id}");
            response.EnsureSuccessStatusCode();
        }




        public async Task UpdateMachineAsync(Machine updatedMachine)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/machines/{updatedMachine.Id}", updatedMachine);
            response.EnsureSuccessStatusCode();
        }


       
    }
}
