using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace COREMES.Core
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        Task<IEnumerable<Vehicle>> GetVehicles();
        void Remove(Vehicle vehicle);
    }
}