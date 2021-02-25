using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persistence;
using Core.Models;
using Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly CoreDbContext context;
        private readonly IMapper mapper;
        public MakesController(CoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Make.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);

        }

    }
}