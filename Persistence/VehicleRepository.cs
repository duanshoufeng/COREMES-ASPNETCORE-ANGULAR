using System.Collections.Generic;
using System.Threading.Tasks;
using COREMES.Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{

    public class VehicleRepository : IVehicleRepository
    {
        private readonly CoreDbContext context;
        public VehicleRepository(CoreDbContext context)
        {
            this.context = context;

        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicle.FindAsync(id);

            return await context.Vehicle
                .Include(v => v.Features)
                    .ThenInclude(fv => fv.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);


        }
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await context.Vehicle
                .Include(v => v.Features)
                    .ThenInclude(fv => fv.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .ToListAsync();

        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicle.Add(vehicle);

        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicle.Remove(vehicle);
        }
    }
}