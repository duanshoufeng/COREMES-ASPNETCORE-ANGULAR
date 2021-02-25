using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CoreDbContext context;
        public FeaturesController(CoreDbContext context)
        {
            this.context = context;

        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await context.Feature.ToListAsync();


        }

    }
}