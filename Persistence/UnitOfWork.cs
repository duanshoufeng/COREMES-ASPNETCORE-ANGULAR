using System.Threading.Tasks;
using COREMES.Core;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreDbContext context;
        public UnitOfWork(CoreDbContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }


    }
}